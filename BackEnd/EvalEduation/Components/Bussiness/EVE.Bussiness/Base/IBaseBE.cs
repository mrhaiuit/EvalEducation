﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EVE.Bussiness
{
    public interface IBaseBE<T>
            where T : class
    {
        #region Get

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter,
                                      string includeProperties = "");

        Task<T> FindOneAsync(Expression<Func<T, bool>> filter,
                             string includeProperties = "");

        #endregion Get

        #region Actions

        void Delete(T obj);

        void Insert(T obj);

        void Update(T obj);

        void SubmitChange();

        #endregion Actions

        #region Validated

        #endregion Validated
    }
}
