﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace E_Commerce2.Localization
{
    internal class GlobalTemplatePageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            var selectorCount = model.Selectors.Count;
            for (var i = 0; i < selectorCount; i++)
            {
                var selector = model.Selectors[i];
                model.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Order = -1,
                        Template = AttributeRouteModel.CombineTemplates(
                            "{culture?}",
                            selector.AttributeRouteModel.Template)
                    }
                });
            }
        }
    }
}
