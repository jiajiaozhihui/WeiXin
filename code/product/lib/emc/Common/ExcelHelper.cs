using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;
namespace SfSoft.Common
{
    public class ExcelHelper
    {
        private Excel._Application excelApp;
        private string fileName = string.Empty;
        private Excel.WorkbookClass wbclass;
        public ExcelHelper(string _filename)
        {
            excelApp = new Excel.Application();
            object objOpt = System.Reflection.Missing.Value;
            wbclass = (Excel.WorkbookClass)excelApp.Workbooks.Open(_filename, objOpt, false, objOpt, objOpt, objOpt, true, objOpt, objOpt, true, objOpt, objOpt, objOpt, objOpt, objOpt);
        }
        /// <summary>
        /// 所有sheet的名称列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetSheetNames()
        {
            List<string> list = new List<string>();
            Excel.Sheets sheets = wbclass.Worksheets;
            string sheetNams = string.Empty;
            foreach (Excel.Worksheet sheet in sheets)
            {
                list.Add(sheet.Name);
            }
            return list;
        }
        public Excel.Worksheet GetWorksheetByName(string name)
        {
            Excel.Worksheet sheet = null;
            Excel.Sheets sheets = wbclass.Worksheets;
            foreach (Excel.Worksheet s in sheets)
            {
                if (s.Name == name)
                {
                    sheet = s;
                    break;
                }
            }
            return sheet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public Array GetContent(string sheetName)
        {
            Excel.Worksheet sheet = GetWorksheetByName(sheetName);
            //获取A1 到AM24范围的单元格
            Excel.Range rang = sheet.get_Range("A3", "AM24");
            //读一个单元格内容
            //sheet.get_Range("A1", Type.Missing);
            //不为空的区域,列,行数目
            //   int l = sheet.UsedRange.Columns.Count;
            // int w = sheet.UsedRange.Rows.Count;
            //  object[,] dell = sheet.UsedRange.get_Value(Missing.Value) as object[,];
            System.Array values = (Array)rang.Cells.Value2;
            return values;
        }

        public void Close()
        {
            excelApp.Quit();
            excelApp = null;
        }

        public  static DataSet GetDataSet(string filePath)
        {
            string Connstr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filePath + "';Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
            OleDbConnection Conn = new OleDbConnection(Connstr);
            //创建ArrayList对象 存放所有sheetname    
            ArrayList sheetNamelist = new ArrayList();
            //获取配置Excel中sheet总数(这里是根据项目需求配置的) 如果需要导入Excel表格所有sheet数据则将此代码删除  
           // int sheetCount = Convert.ToInt32(ConfigurationManager.AppSettings["sheetCount"].ToString());
            DataSet dsExcel = new DataSet();
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                System.Data.DataTable dtExcelSchema = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                 List<string> sheetNames = new List<string>();
                if (dtExcelSchema.Rows.Count > 12)
                {
                    //        Page.RegisterStartupScript("", "<mce:script type="text/javascript"><!--  
                    // alert('很抱歉!你上传Excel文件sheet总数过多不能大于10个sheet..!! ')  
                    // --></mce:script>");  
                    return null;
                }
                else
                {
                    foreach (DataRow var in dtExcelSchema.Rows)
                    {
                        sheetNamelist.Add(var[2].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString(), ex);
            }
            finally
            {
                Conn.Close();
            }
            try
            {
                string strSQL = string.Empty;
                for (int i = 0; i < sheetNamelist.Count; i++)
                {
                    strSQL = "select * from [" + sheetNamelist[i].ToString() + "]";
                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, Conn);
                    System.Data.DataTable dtExcel = new System.Data.DataTable(sheetNamelist[i].ToString());
                    da.Fill(dtExcel);
                    dsExcel.Tables.Add(dtExcel);
                }
                return dsExcel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString(), ex);
            }
        }
    }
}