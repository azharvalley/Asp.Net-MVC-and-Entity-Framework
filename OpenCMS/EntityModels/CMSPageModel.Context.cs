﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenCMS.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBCMSEntities : DbContext
    {
        public DBCMSEntities()
            : base("name=DBCMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CMSPage> CMSPages { get; set; }
    
        public virtual ObjectResult<Nullable<decimal>> AddPage(Nullable<int> id, string slug, string pTitle, string pKeyword, string pDescription, string pageContent, Nullable<bool> isActive, Nullable<bool> isDelete)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var slugParameter = slug != null ?
                new ObjectParameter("Slug", slug) :
                new ObjectParameter("Slug", typeof(string));
    
            var pTitleParameter = pTitle != null ?
                new ObjectParameter("PTitle", pTitle) :
                new ObjectParameter("PTitle", typeof(string));
    
            var pKeywordParameter = pKeyword != null ?
                new ObjectParameter("PKeyword", pKeyword) :
                new ObjectParameter("PKeyword", typeof(string));
    
            var pDescriptionParameter = pDescription != null ?
                new ObjectParameter("PDescription", pDescription) :
                new ObjectParameter("PDescription", typeof(string));
    
            var pageContentParameter = pageContent != null ?
                new ObjectParameter("PageContent", pageContent) :
                new ObjectParameter("PageContent", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var isDeleteParameter = isDelete.HasValue ?
                new ObjectParameter("IsDelete", isDelete) :
                new ObjectParameter("IsDelete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("AddPage", idParameter, slugParameter, pTitleParameter, pKeywordParameter, pDescriptionParameter, pageContentParameter, isActiveParameter, isDeleteParameter);
        }
    
        public virtual int EditPage(Nullable<int> id, string slug, string pTitle, string pKeyword, string pDescription, string pageContent, Nullable<bool> isActive, Nullable<bool> isDelete, ObjectParameter result)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var slugParameter = slug != null ?
                new ObjectParameter("Slug", slug) :
                new ObjectParameter("Slug", typeof(string));
    
            var pTitleParameter = pTitle != null ?
                new ObjectParameter("PTitle", pTitle) :
                new ObjectParameter("PTitle", typeof(string));
    
            var pKeywordParameter = pKeyword != null ?
                new ObjectParameter("PKeyword", pKeyword) :
                new ObjectParameter("PKeyword", typeof(string));
    
            var pDescriptionParameter = pDescription != null ?
                new ObjectParameter("PDescription", pDescription) :
                new ObjectParameter("PDescription", typeof(string));
    
            var pageContentParameter = pageContent != null ?
                new ObjectParameter("PageContent", pageContent) :
                new ObjectParameter("PageContent", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var isDeleteParameter = isDelete.HasValue ?
                new ObjectParameter("IsDelete", isDelete) :
                new ObjectParameter("IsDelete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditPage", idParameter, slugParameter, pTitleParameter, pKeywordParameter, pDescriptionParameter, pageContentParameter, isActiveParameter, isDeleteParameter, result);
        }
    
        public virtual ObjectResult<FetchAllPages_Result> FetchAllPages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FetchAllPages_Result>("FetchAllPages");
        }
    
        public virtual ObjectResult<FetchPageById_Result> FetchPageById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FetchPageById_Result>("FetchPageById", idParameter);
        }
    
        public virtual ObjectResult<FetchPageBySlug_Result> FetchPageBySlug(string slug)
        {
            var slugParameter = slug != null ?
                new ObjectParameter("Slug", slug) :
                new ObjectParameter("Slug", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FetchPageBySlug_Result>("FetchPageBySlug", slugParameter);
        }
    
        public virtual ObjectResult<FetchPageInfoById_Result> FetchPageInfoById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FetchPageInfoById_Result>("FetchPageInfoById", idParameter);
        }
    
        public virtual int InsertPage(Nullable<int> id, string slug, string pTitle, string pKeyword, string pDescription, string pageContent, Nullable<bool> isActive, Nullable<bool> isDelete, ObjectParameter result, ObjectParameter createdId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var slugParameter = slug != null ?
                new ObjectParameter("Slug", slug) :
                new ObjectParameter("Slug", typeof(string));
    
            var pTitleParameter = pTitle != null ?
                new ObjectParameter("PTitle", pTitle) :
                new ObjectParameter("PTitle", typeof(string));
    
            var pKeywordParameter = pKeyword != null ?
                new ObjectParameter("PKeyword", pKeyword) :
                new ObjectParameter("PKeyword", typeof(string));
    
            var pDescriptionParameter = pDescription != null ?
                new ObjectParameter("PDescription", pDescription) :
                new ObjectParameter("PDescription", typeof(string));
    
            var pageContentParameter = pageContent != null ?
                new ObjectParameter("PageContent", pageContent) :
                new ObjectParameter("PageContent", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var isDeleteParameter = isDelete.HasValue ?
                new ObjectParameter("IsDelete", isDelete) :
                new ObjectParameter("IsDelete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertPage", idParameter, slugParameter, pTitleParameter, pKeywordParameter, pDescriptionParameter, pageContentParameter, isActiveParameter, isDeleteParameter, result, createdId);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdatePage(Nullable<int> id, string slug, string pTitle, string pKeyword, string pDescription, string pageContent, Nullable<bool> isActive, Nullable<bool> isDelete)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var slugParameter = slug != null ?
                new ObjectParameter("Slug", slug) :
                new ObjectParameter("Slug", typeof(string));
    
            var pTitleParameter = pTitle != null ?
                new ObjectParameter("PTitle", pTitle) :
                new ObjectParameter("PTitle", typeof(string));
    
            var pKeywordParameter = pKeyword != null ?
                new ObjectParameter("PKeyword", pKeyword) :
                new ObjectParameter("PKeyword", typeof(string));
    
            var pDescriptionParameter = pDescription != null ?
                new ObjectParameter("PDescription", pDescription) :
                new ObjectParameter("PDescription", typeof(string));
    
            var pageContentParameter = pageContent != null ?
                new ObjectParameter("PageContent", pageContent) :
                new ObjectParameter("PageContent", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var isDeleteParameter = isDelete.HasValue ?
                new ObjectParameter("IsDelete", isDelete) :
                new ObjectParameter("IsDelete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdatePage", idParameter, slugParameter, pTitleParameter, pKeywordParameter, pDescriptionParameter, pageContentParameter, isActiveParameter, isDeleteParameter);
        }
    
        public virtual int DeletePageById(Nullable<long> id, ObjectParameter result)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePageById", idParameter, result);
        }
    }
}