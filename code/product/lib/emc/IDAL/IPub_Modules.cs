﻿using System;
using System.Data;
namespace SfSoft.IDAL
{
    /// <summary>
    /// 接口层IPub_Modules 的摘要说明。
    /// </summary>
    public interface IPub_Modules
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ModulesID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(SfSoft.Model.Pub_Modules model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(SfSoft.Model.Pub_Modules model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string ModulesID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        SfSoft.Model.Pub_Modules GetModel(string ModulesID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}