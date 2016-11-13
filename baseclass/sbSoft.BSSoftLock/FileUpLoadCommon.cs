using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Configuration;
namespace sbSoft.BSSoftLock
{
    /// <summary>
    /// 通用上传文件类


    /// </summary>
    public class FileUpLoadCommon
    {
        #region "Private Variables"
        private string _path;                   // 上传文件的路径


        private string _fileName;               // 文件名称
        private string _newFileName = "";            // 新的文件名
        private string _errorMsg="";               // 错误信息


        private int _fileSize = 0;          // 大小
        private string _fileType;           // 文件类型
        private string _fileExt; //文件扩展名
        private string _webFilePath;            // 服务器端文件路径

        #endregion



        #region 属性 -- 旧文件名
        /// <summary>
        /// 旧文件名
        /// </summary>
        public string fileName
        {
            get
            {
                return _fileName;
            }
        }
        #endregion
        #region "出错信息"
        /// <summary>
        /// 出错信息
        /// </summary>
        public string errorMsg
        {
            get
            {
                return _errorMsg;
            }
        }
        #endregion

      #region 属性 -- 上传的文件的路径
        /// <summary>
        /// 上传的文件的路径
        /// </summary>
        public string path
        {
            get
            {
                return _path;
            }
        }
        #endregion

        #region 属性 -- 文件大小
        /// <summary>
        /// 文件大小
        /// </summary>
        public int fileSize
        {
            get
            {
                return _fileSize;
            }
        }
        #endregion


        #region 属性 -- 文件的类型


        /// <summary>
        /// 文件的类型


        /// </summary>
        public string fileType
        {
            get { return _fileType; }
        }
        #endregion

        #region "文件扩展名"
        /// <summary>
        /// 文件扩展名


        /// </summary>
        public string fileExt
        {
            get
            {
                return _fileExt;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FileUpLoadCommon()
            : this("/Configuration/")
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="isDate">是否按日期创建目录</param>
        public FileUpLoadCommon(string filePath)
        {
            _path = filePath;
            string p = HttpContext.Current.Server.MapPath(_path);
            //如果目录不存在,将创建目录
            if (!Directory.Exists(p))
                Directory.CreateDirectory(p);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filepath">服务器保存路径，相对根目录</param>
        /// <param name="file">上传文件对象</param>
        /// <returns>成功/失败</returns>
        public static bool UpFile(string filepath, FileUpload file)
        {
            FileUpLoadCommon fc = new FileUpLoadCommon(filepath);
            return fc.SaveFile(file);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fu">上传文件对象</param>
        /// <returns>成功/失败</returns>
        public bool SaveFile(FileUpload fu)
        {
            bool rBool = false;
            rBool = SaveFile(fu.PostedFile);
            fu.Dispose();
            return rBool;
        }

        #region 方法 -- 保存文件
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fu">上传文件对象</param>
        /// <returns>成功/失败</returns>
        public bool SaveFile(HttpPostedFile fu)
        {
            if (fu.ContentLength > 0)
            {
                string fileContentType = fu.ContentType;
                string name = fu.FileName;                        // 客户端文件路径
                FileInfo file = new FileInfo(name);
                _fileExt = file.Extension;
                _fileType = fu.ContentType;
                _fileSize = fu.ContentLength;
                _fileName = file.Name;
                //检测文件扩展名是否正确
                string LicenseExtName = ConfigurationManager.AppSettings["License:ExtName"];
                if (!bsSoftLock.Check_Char_Is(file.Extension.Substring(1).ToLower(), LicenseExtName.ToLower()))
                {
                    _errorMsg = string.Format("文件扩展名不符合系统要求:{0}", LicenseExtName);
                    return false;
                }
                // 文件名称
                _webFilePath = HttpContext.Current.Server.MapPath(_path + _fileName);         // 服务器端文件路径
                //检查文件是否存在
                try
                {
                    fu.SaveAs(_webFilePath);                                 // 使用 SaveAs 方法保存文件     

                    return true;
                }
                catch (Exception ex)
                {
                    _errorMsg = "提示：文件上传失败，失败原因：" + ex.Message;
                }

            }
            else
            {
                _errorMsg = "提示:文件不能为空,请选择要上传文件!";
            }
            return false;
        }
        #endregion

        #region 方法 -- 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filename"></param>
        public static void DeleteFile(string filename)
        {
            string s = HttpContext.Current.Server.MapPath(filename);
            if (File.Exists(s))
            {
                try
                {
                    File.Delete(s);
                }
                catch
                { }
            }
        }
        #endregion


        /// <summary>
        /// 取扩展名
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetExtName(string FileName)
        {
            string ExtName = "";
            if (FileName != "")
            {
                int l = FileName.LastIndexOf('.');
                ExtName = FileName.Substring(l + 1, FileName.Length - l - 1);
            }
            return ExtName;
        }
        /// <summary>
        /// 取文件名不带扩展名


        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetFileName(string FileName)
        {
            string FName = "";
            if (FileName != "")
            {
                int l = FileName.LastIndexOf('.');
                FName = FileName.Substring(0, l);
            }
            return FName;
        }
    }
}
