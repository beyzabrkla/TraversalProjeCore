using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TAdd(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public void TUpdate(AppUser t)
        {
            var existingUser = _appUserDal.GetById(t.Id);

            if (existingUser != null)
            {
                existingUser.Name = t.Name;
                existingUser.Surname = t.Surname;
                existingUser.UserName = t.UserName;
                existingUser.Email = t.Email;
                existingUser.PhoneNumber = t.PhoneNumber;
                existingUser.ImageUrl = t.ImageUrl;

                // Identity ConcurrencyStamp'ı güncel nesneye kopyalayın
                existingUser.ConcurrencyStamp = t.ConcurrencyStamp;

                _appUserDal.Update(existingUser);
            }
        }
    }
}