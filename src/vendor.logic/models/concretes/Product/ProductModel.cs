using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using vendor.domain.entities;
using vendor.logic.models.abstracts;
using vendor.domain.entities.manytomany;

namespace vendor.logic.models.concretes
{
    public class ProductModel : IModelProduct
    {
        private readonly IValidatorProduct _validator;
        private readonly IModel<Product> _model;
        /// private readonly IModel<UserProduct> _up;

        public ProductModel(
            IValidatorProduct validator, 
            IModel<Product> model) // ,
            /// IModel<UserProduct> up)
        {
            this._model = model;

            this._validator = validator;

            // this._up = up;
        }

        public ResultProduct Get(long id)
        {
            var product = this._model.Get(x => x.Id == id);

            var result  = new ResultProduct();

            result.Results.Add(product);

            return result;
        }

        public ResultProduct List(Expression<Func<Product, bool>> filter = null)
        {
            return new ResultProduct { Results = this._model.List(filter) as ICollection<Product> };
        }

        public ResultProduct Add(Product entry, User user, long languageId)
        {
            var result = new ResultProduct { Results = null, Error = this._validator.Validate(entry) };

            if (!result.Error.IsValid) { return result; }

            var product = UpdateOfProductLanguage(entry, languageId);

            product.Image = entry.Image;

            // product.Update = entry.Update;

            product.UserUpdate = user;

            this._model.SaveChange();

            return result;
        }

        /// <summary>
        /// Update of only admin
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="user"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public ResultProduct Update(Product entry, User user, long languageId)
        {
            var result = new ResultProduct { Results = null, Error = this._validator.Validate(entry) };

            if (!result.Error.IsValid) { return result; }

            var product = UpdateOfProductLanguage(entry, languageId);

            product.Image = entry.Image;

            // product.Update = entry.Update;

            product.UserUpdate = user;

            this._model.SaveChange();

            return result;
        }

        public Product UpdateOfProductLanguage(Product entry, long languageId)
        {
            var product = this._model.Set
                .Include(p => p.ProductLanguages.Where(x => x.LanguageId == languageId))
                .Include(p => p.UserUpdate)
                .SingleOrDefaultAsync(p => p.Id == entry.Id).Result;

            var pl = product.ProductLanguages.Single();

            pl.Name = entry.ProductLanguages.Single(x => x.LanguageId == languageId).Name;

            pl.Description = entry.ProductLanguages.Single(x => x.LanguageId == languageId).Description;

            // pl.Update = entry.Update;

            pl.UserUpdate = entry.UserUpdate;

            return product;
        }

        public ResultUserProduct AddedOfUserProductToCart(Product entry, User user)
        {
            var up = new UserProduct
            {
                Parent = user,
                Product = entry,
                // AddedDate = entry.Update,
                // BuyingDate = null
            };

            // this._up.Add(up);

            // this._up.SaveChange();

            return new ResultUserProduct { Results = new List<UserProduct> { up }, Error = null };
        }

        public ResultProduct Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            this._model.Dispose();
        }

        public ResultProduct Update(Product entry, User user)
        {
            throw new NotImplementedException();
        }

        public ResultProduct Add(Product entry)
        {
            throw new NotImplementedException();
        }
    }
}
