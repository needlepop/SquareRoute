﻿using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/AccessCode")]
    public class AccessCodeController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public AccessCodeController()
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region AccessCode Methods
        #region AccessCode CREATE
        // POST api/AccessCode/AddAccessCode
        [Route("AddAccessCode")]
        public IHttpActionResult AddAccessCode(AccessCode accessCode)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AccessCodeRepository.Repo.Add(accessCode);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region AccessCode GET
        // GET api/AccessCode/GetAccessCodeById/id
        [Route("GetAccessCodeById/{id}")]
        public AccessCode GetAccessCodeById(int id)
        {
            return _unitOfWork.AccessCodeRepository.GetAccessCodeById(id);
        }

        // GET api/AccessCode/GetAccessCodeByValue/accessCodeValue
        [Route("GetAccessCodeByValue/{accessCodeValue}")]
        public AccessCode GetAccessCodeByName(string accessCodeValue)
        {
            return _unitOfWork.AccessCodeRepository.GetAccessCodeByValue(accessCodeValue);
        }

        // GET api/AccessCode/GetAllAccessCodes
        [Route("GetAllAccessCodes")]
        public IList<AccessCode> GetAllAccessCodes()
        {
            return _unitOfWork.AccessCodeRepository.Repo.GetAll();
        }


        #endregion

        #region AccessCode UPDATE
        // POST api/AccessCode/UpdateAccessCode
        [Route("UpdateAccessCode")]
        public IHttpActionResult UpdateAccessCode(AccessCode accessCode)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AccessCodeRepository.Repo.Update(accessCode);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        #endregion

        #region AccessCode Delete
        // POST api/AccessCode/DeleteAccessCodeById/id
        [Route("DeleteAccessCodeById/{id}")]
        public IHttpActionResult DeleteAccessCodeById(int id)
        {
            _unitOfWork.AccessCodeRepository.DeleteAccessCodeById(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion
        #endregion
    }
}