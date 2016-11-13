using System;
using System.Collections.Generic;
using System.Text;

namespace sbSoft.BSSoftLock
{
    /// <summary>
    /// 系统配置表
    /// </summary>
    [Serializable]
    public sealed class EMC_SoftLockConfig
    {
        private static readonly string _productNo = "{C5610424-044C-4E0D-94BB-8CD895410D44}";
        private static readonly string _version = "V5.5";

        /// <summary>
        /// 产品编号
        /// </summary>
        public static string ProductNo
        {
            get
            {
                return _productNo;
            }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version
        {
            get
            {
                return _version;
            }
        }
    }
}
