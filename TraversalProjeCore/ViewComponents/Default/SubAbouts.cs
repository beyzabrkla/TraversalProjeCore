using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.Default
{
    public class SubAbouts :ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EFSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = subAboutManager.TGetList();
            return View(values); 
        }
    }
}
