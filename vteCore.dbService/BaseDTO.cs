﻿using Mapster;
using System.Runtime.CompilerServices;

namespace vteCore.dbService
{
    /// <summary>
    /// Base Data Transfer Object for model mapping.
    /// </summary>
    /// <typeparam name="TDto">The type of the DTO.</typeparam>
    /// <typeparam name="TModel">The type of the Model.</typeparam>
    public abstract class BaseDto<TDto, TModel>: IRegister
        where TDto : class, new()
        where TModel : class, new()
    {
        /// <summary>
        /// Configuration of type adapter.
        /// </summary>
        private TypeAdapterConfig Config { get; set; }


        /// <summary>
        /// Adds custom mappings to the configuration.
        /// </summary>
        public virtual void AddCustomMappings() { SetCustomMappings(); SetCustomMappingsReverse(); }

        /// <summary>
        /// Sets custom mappings for dto to model.
        /// </summary>
        /// <returns>The type adapter setter.</returns>
        protected TypeAdapterSetter<TDto, TModel> SetCustomMappings() => Config.ForType<TDto, TModel>();

        /// <summary>
        /// Sets custom mappings for model to dto.
        /// </summary>
        /// <returns>The type adapter setter.</returns>
        protected TypeAdapterSetter<TModel, TDto> SetCustomMappingsReverse() => Config.ForType<TModel, TDto>();

        /// <summary>
        /// Registers the type adapter configuration and adds custom mappings.
        /// </summary>
        /// <param name="config">The configuration of the type adapter.</param>
        public void Register(TypeAdapterConfig config)
        {
            Config = config;
            AddCustomMappings();
        }

        /// <summary>
        /// Maps DTO to an existing Model.
        /// </summary>
        /// <returns>The Model.</returns>
        public static TModel ToModel(TDto dto)
        {
            return dto.Adapt<TModel>();
            
        }

        /// <summary>
        /// Maps DTO to an existing Model.
        /// </summary>
        /// <param name="model">The existing Model instance to be updated.</param>
        /// <returns>The updated Model instance.</returns>
        public static  TModel ToModel(TDto dto,TModel model)
        {
            return dto.Adapt(model);
            
        }

        /// <summary>
        /// Maps a Model to a DTO.
        /// </summary>
        /// <param name="model">The Model to be mapped.</param>
        /// <returns>The DTO.</returns>
        public static TDto FromModel(TModel model)
        {
            var dto= model.Adapt<TDto>();
            
            return dto;
        }
    }
}
