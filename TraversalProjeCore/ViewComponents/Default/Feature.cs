using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.Default
{
    public class Feature:ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDal());

        public IViewComponentResult Invoke()
        {
         //   var values = featureManager.TGetList();
         //   ViewBag.image1=featureManager.get
            return View();
        }
    }
}
