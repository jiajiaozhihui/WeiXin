using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using sbSoft.SoftLock.Library;
using sbSoft.SoftLock.Database;
using sbSoft.SoftLock;
namespace sbSoft.BSSoftLock
{
    public class bsSoftLock
    {
        private static readonly string LicenseFilesPath = ConfigurationManager.AppSettings["License:FilesPath"];

        /// <summary>
        /// 获取EMC产品编号
        /// </summary>
        public static string EMC_ProductNo
        {
            get { return EMC_SoftLockConfig.ProductNo; }
        }

        /// <summary>
        /// 取的电脑系列号
        /// </summary>
        /// <returns></returns>
        public static string GetComputerSN()
        {
            return LicenseManager.GetLocalSerialNo();
        }

        /// <summary>
        /// 获取最后一次的错误信息
        /// </summary>
        public static string LastError { get; private set; }

        /// <summary>
        /// 导入一份许可文件
        /// </summary>
        /// <param name="ImportFilesName"></param>
        /// <returns></returns>
        public static bool ImportLicense(string ImportFilesName)
        {
            try
            {
                // 服务器端文件路径
                string webFilePath = HttpContext.Current.Server.MapPath(LicenseFilesPath + ImportFilesName);

                //导入许可文件
                LicenseManager.Instance.ImportLicenseFile(EMC_ProductNo, webFilePath);

                //检查是否可以获取注册后的许可，以便验证许可的有效性
                LicenseManager.Instance.GetProductLicence(EMC_ProductNo);

                LastError = "";

                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 判断是否已经注册
        /// </summary>
        /// <returns></returns>
        public static bool IsRegister()
        {
            return LicenseManager.Instance.IsRegister(EMC_ProductNo);
        }

        /// <summary>
        /// 取的产品注册信息
        /// </summary>
        /// <param name="ProductNo"></param>
        /// <returns></returns>
        public static string GetLinceseDesc()
        {
            try
            {
                ProductLicence pl = LicenseManager.Instance.GetProductLicence(EMC_ProductNo);

                string proDesc = "产品名称：" + pl.License.Product.DisplayName + "\n";
                proDesc += "版 本 号：" + pl.License.Product.Version + "\n";
                proDesc += "公 司 数：" + pl.License.AllowAccounts.ToString() + "\n";
                proDesc += "用 户 数：" + pl.License.AllowUsers.ToString() + "\n";
                proDesc += "激活日期：" + pl.License.ActiveDate + "\n";
                if (pl.License.IsLimit)
                {
                    proDesc += "用效日期：" + pl.License.LimitDate + "\n";
                }
                LastError = "";
                return proDesc;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return ex.Message;
            }
        }

        /// <summary>
        /// 取的公司数
        /// </summary>
        /// <returns></returns>
        public static int GetAllowAccounts()
        {
            try
            {
                ProductLicence pl = LicenseManager.Instance.GetProductLicence(EMC_ProductNo);
                LastError = "";
                return pl.License.AllowAccounts;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 取的用户数
        /// </summary>
        /// <returns></returns>
        public static int GetAllowUsers()
        {
            try
            {
                ProductLicence pl = LicenseManager.Instance.GetProductLicence(EMC_ProductNo);
                LastError = "";
                return pl.License.AllowUsers;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 移除许可
        /// </summary>
        /// <returns></returns>
        public static bool RemoveLincese()
        {
            try
            {
                LicenseManager.Instance.RemoveProductLicence(EMC_ProductNo);
                LastError = "";
                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 检查许可有效性
        /// </summary>
        /// <param name="ProductNo"></param>
        /// <returns></returns>
        public static bool IsValidLincese()
        {
            try
            {
                ProductLicence pl = LicenseManager.Instance.GetProductLicence(EMC_ProductNo);

                pl.CheckLicense();
                LastError = "";

                return true;
            }
            catch (InvalidOperationException ex)
            {
                LastError = ex.Message;
            }
            catch
            {
                LastError = "注册文件有错！";
            }

            return false;
        }

        #region "检测当前字符是否在以,号分开的字符串中(xx,sss,xaf,fdsf)"
        /// <summary>
        /// 检测当前字符是否在以,号分开的字符串中(xx,sss,xaf,fdsf)
        /// </summary>
        /// <param name="TempChar">需检测字符</param>
        /// <param name="TempStr">待检测字符串</param>
        /// <returns>存在true,不存在false</returns>
        public static bool Check_Char_Is(string TempChar, string TempStr)
        {
            bool rBool = false;
            if (TempChar != null && TempStr != null)
            {
                string[] TempStrArray = TempStr.Split(',');
                for (int i = 0; i < TempStrArray.Length; i++)
                {
                    if (TempChar == TempStrArray[i].Trim())
                    {
                        rBool = true;
                        break;
                    }
                }
            }
            return rBool;
        }
        #endregion

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
    }

}
