using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        List<ImageDetails> assetStatusImageLst = new List<ImageDetails>();
        List<ImageDetails> gnNumberImageLst = new List<ImageDetails>();
        List<ImageDetails> crNumberImageLst = new List<ImageDetails>();
        List<ImageDetails> courtOrderImageLst = new List<ImageDetails>();
        List<ImageDetails> surveyNoImageLst = new List<ImageDetails>();
        List<ImageDetails> khathaNoImageLst = new List<ImageDetails>();
        List<ImageDetails> municipalNoImageLst = new List<ImageDetails>();
        List<ImageDetails> northImageLst = new List<ImageDetails>();
        List<ImageDetails> eastImageLst = new List<ImageDetails>();
        List<ImageDetails> southImageLst = new List<ImageDetails>();
        List<ImageDetails> westImageLst = new List<ImageDetails>();
        List<ImageDetails> estimatedValueImageLst = new List<ImageDetails>();
        List<ImageDetails> litigationManagementImageLst = new List<ImageDetails>();
        List<ImageDetails> litigationAssetImageLst = new List<ImageDetails>();
        List<ImageDetails> geoStampedImageLst = new List<ImageDetails>();

        List<ImageDetails> managementImageLst = new List<ImageDetails>();
        List<ImageDetails> advisoryImageLst = new List<ImageDetails>();


        public ActionResult OpenAssetStatusUpload()
        {
            return PartialView("~/Views/Image/PartialOpenAssetStatusUpload.cshtml");
        }

        public void OpenAssetStatusUploadFileSave()
        {
            
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "assetStatus";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["assetStatusImageLst"] == null)
                        {
                            assetStatusImageLst.Add(imgObj);
                        }
                        else
                        {
                            assetStatusImageLst = (List<ImageDetails>)HttpContext.Session["assetStatusImageLst"];
                            assetStatusImageLst.Add(imgObj);
                        }

                        HttpContext.Session["assetStatusImageLst"] = assetStatusImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void RemoveAssetStatusUploadedFile(string fileName)
        {
            assetStatusImageLst = (List<ImageDetails>)HttpContext.Session["assetStatusImageLst"];

            foreach (var i in assetStatusImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    assetStatusImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["assetStatusImageLst"] = assetStatusImageLst;
        }


        public ActionResult OpenGnNumberUpload()
        {
            return PartialView("~/Views/Image/PartialOpenGnNumberUpload.cshtml");
        }

        public void OpengnNumberUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "gnNumber";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["gnNumberImageLst"] == null)
                        {
                            gnNumberImageLst.Add(imgObj);
                        }
                        else
                        {
                            gnNumberImageLst = (List<ImageDetails>)HttpContext.Session["gnNumberImageLst"];
                            gnNumberImageLst.Add(imgObj);
                        }

                        HttpContext.Session["gnNumberImageLst"] = gnNumberImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void RemovegnNumberUploadedFile(string fileName)
        {
            gnNumberImageLst = (List<ImageDetails>)HttpContext.Session["gnNumberImageLst"];

            foreach (var i in gnNumberImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    gnNumberImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["gnNumberImageLst"] = gnNumberImageLst;
        }



        public ActionResult OpenCrNumberUpload()
        {
            return PartialView("~/Views/Image/PartialOpenCrNumberUpload.cshtml");
        }

        public void OpenCrNumberUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "crNumber";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["crNumberImageLst"] == null)
                        {
                            crNumberImageLst.Add(imgObj);
                        }
                        else
                        {
                            crNumberImageLst = (List<ImageDetails>)HttpContext.Session["crNumberImageLst"];
                            crNumberImageLst.Add(imgObj);
                        }

                        HttpContext.Session["crNumberImageLst"] = crNumberImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void RemoveCrNumberUploadedFile(string fileName)
        {
            crNumberImageLst = (List<ImageDetails>)HttpContext.Session["crNumberImageLst"];

            foreach (var i in crNumberImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    crNumberImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["crNumberImageLst"] = crNumberImageLst;
        }

        public ActionResult OpenCourtOrderUpload()
        {
            return PartialView("~/Views/Image/PartialOpenCourtOrderUpload.cshtml");
        }

        public void OpenCourtOrderUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "courtOrder";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["courtOrderImageLst"] == null)
                        {
                            courtOrderImageLst.Add(imgObj);
                        }
                        else
                        {
                            courtOrderImageLst = (List<ImageDetails>)HttpContext.Session["courtOrderImageLst"];
                            courtOrderImageLst.Add(imgObj);
                        }

                        HttpContext.Session["courtOrderImageLst"] = courtOrderImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void RemoveCourtOrderUploadedFile(string fileName)
        {
            courtOrderImageLst = (List<ImageDetails>)HttpContext.Session["courtOrderImageLst"];

            foreach (var i in courtOrderImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    courtOrderImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["courtOrderImageLst"] = courtOrderImageLst;
        }


        public ActionResult OpenSurveyNoUpload()
        {
            return PartialView("~/Views/Image/PartialOpenSurveyNoUpload.cshtml");
        }

        public void OpenSurveyNoUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "surveyNo";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["surveyNoImageLst"] == null)
                        {
                            surveyNoImageLst.Add(imgObj);
                        }
                        else
                        {
                            surveyNoImageLst = (List<ImageDetails>)HttpContext.Session["surveyNoImageLst"];
                            surveyNoImageLst.Add(imgObj);
                        }

                        HttpContext.Session["surveyNoImageLst"] = surveyNoImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void RemoveSurveyNoUploadedFile(string fileName)
        {
            surveyNoImageLst = (List<ImageDetails>)HttpContext.Session["surveyNoImageLst"];

            foreach (var i in surveyNoImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    surveyNoImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["surveyNoImageLst"] = surveyNoImageLst;
        }


        public ActionResult OpenKhathaNoUpload()
        {
            return PartialView("~/Views/Image/PartialOpenKhathaNoUpload.cshtml");
        }

        public void OpenKhathaNoUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "khathaNo";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["khathaNoImageLst"] == null)
                        {
                            khathaNoImageLst.Add(imgObj);
                        }
                        else
                        {
                            khathaNoImageLst = (List<ImageDetails>)HttpContext.Session["khathaNoImageLst"];
                            khathaNoImageLst.Add(imgObj);
                        }

                        HttpContext.Session["khathaNoImageLst"] = khathaNoImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void RemoveKhathaNoUploadedFile(string fileName)
        {
            khathaNoImageLst = (List<ImageDetails>)HttpContext.Session["khathaNoImageLst"];

            foreach (var i in khathaNoImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    khathaNoImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["khathaNoImageLst"] = khathaNoImageLst;
        }


        public ActionResult OpenMunicipalNoUpload()
        {
            return PartialView("~/Views/Image/PartialOpenMunicipalNoUpload.cshtml");
        }

        public void OpenMunicipalNoUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "municipalNo";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["municipalNoImageLst"] == null)
                        {
                            municipalNoImageLst.Add(imgObj);
                        }
                        else
                        {
                            municipalNoImageLst = (List<ImageDetails>)HttpContext.Session["municipalNoImageLst"];
                            municipalNoImageLst.Add(imgObj);
                        }

                        HttpContext.Session["municipalNoImageLst"] = municipalNoImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveMunicipalNoUploadedFile(string fileName)
        {
            municipalNoImageLst = (List<ImageDetails>)HttpContext.Session["municipalNoImageLst"];

            foreach (var i in municipalNoImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    municipalNoImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["municipalNoImageLst"] = municipalNoImageLst;
        }


        public ActionResult OpenNorthUpload()
        {
            return PartialView("~/Views/Image/PartialOpenNorthUpload.cshtml");
        }

        public void OpenNorthUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "north";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["northImageLst"] == null)
                        {
                            northImageLst.Add(imgObj);
                        }
                        else
                        {
                            northImageLst = (List<ImageDetails>)HttpContext.Session["northImageLst"];
                            northImageLst.Add(imgObj);
                        }

                        HttpContext.Session["northImageLst"] = northImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveNorthUploadedFile(string fileName)
        {
            northImageLst = (List<ImageDetails>)HttpContext.Session["northImageLst"];

            foreach (var i in northImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    northImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["northImageLst"] = northImageLst;
        }

        public ActionResult OpenEastUpload()
        {
            return PartialView("~/Views/Image/PartialOpenEastUpload.cshtml");
        }

        public void OpenEastUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "east";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["eastImageLst"] == null)
                        {
                            eastImageLst.Add(imgObj);
                        }
                        else
                        {
                            eastImageLst = (List<ImageDetails>)HttpContext.Session["eastImageLst"];
                            eastImageLst.Add(imgObj);
                        }

                        HttpContext.Session["eastImageLst"] = eastImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveEastUploadedFile(string fileName)
        {
            eastImageLst = (List<ImageDetails>)HttpContext.Session["eastImageLst"];

            foreach (var i in eastImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    eastImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["eastImageLst"] = eastImageLst;
        }

        public ActionResult OpenSouthUpload()
        {
            return PartialView("~/Views/Image/PartialOpenSouthUpload.cshtml");
        }

        public void OpenSouthUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "south";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["southImageLst"] == null)
                        {
                            southImageLst.Add(imgObj);
                        }
                        else
                        {
                            southImageLst = (List<ImageDetails>)HttpContext.Session["southImageLst"];
                            southImageLst.Add(imgObj);
                        }

                        HttpContext.Session["southImageLst"] = southImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveSouthUploadedFile(string fileName)
        {
            southImageLst = (List<ImageDetails>)HttpContext.Session["southImageLst"];

            foreach (var i in southImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    southImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["southImageLst"] = southImageLst;
        }


        public ActionResult OpenWestUpload()
        {
            return PartialView("~/Views/Image/PartialOpenWestUpload.cshtml");
        }

        public void OpenWestUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "west";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["westImageLst"] == null)
                        {
                            westImageLst.Add(imgObj);
                        }
                        else
                        {
                            westImageLst = (List<ImageDetails>)HttpContext.Session["westImageLst"];
                            westImageLst.Add(imgObj);
                        }

                        HttpContext.Session["westImageLst"] = westImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveWestUploadedFile(string fileName)
        {
            westImageLst = (List<ImageDetails>)HttpContext.Session["westImageLst"];

            foreach (var i in westImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    westImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["westImageLst"] = westImageLst;
        }


        public ActionResult OpenEstimatedValueUpload()
        {
            return PartialView("~/Views/Image/PartialOpenEstimatedValueUpload.cshtml");
        }

        public void OpenEstimatedValueUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "estimatedValue";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["estimatedValueImageLst"] == null)
                        {
                            estimatedValueImageLst.Add(imgObj);
                        }
                        else
                        {
                            estimatedValueImageLst = (List<ImageDetails>)HttpContext.Session["estimatedValueImageLst"];
                            estimatedValueImageLst.Add(imgObj);
                        }

                        HttpContext.Session["estimatedValueImageLst"] = estimatedValueImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveEstimatedValueUploadedFile(string fileName)
        {
            estimatedValueImageLst = (List<ImageDetails>)HttpContext.Session["estimatedValueImageLst"];

            foreach (var i in estimatedValueImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    estimatedValueImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["estimatedValueImageLst"] = estimatedValueImageLst;
        }

        public ActionResult OpenLitigationManagementUpload()
        {
            return PartialView("~/Views/Image/PartialOpenLitigationManagementUpload.cshtml");
        }

        public void OpenLitigationManagementUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "litigationManagement";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["litigationManagementImageLst"] == null)
                        {
                            litigationManagementImageLst.Add(imgObj);
                        }
                        else
                        {
                            litigationManagementImageLst = (List<ImageDetails>)HttpContext.Session["litigationManagementImageLst"];
                            litigationManagementImageLst.Add(imgObj);
                        }

                        HttpContext.Session["litigationManagementImageLst"] = litigationManagementImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveLitigationManagementUploadedFile(string fileName)
        {
            litigationManagementImageLst = (List<ImageDetails>)HttpContext.Session["litigationManagementImageLst"];

            foreach (var i in litigationManagementImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    litigationManagementImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["litigationManagementImageLst"] = litigationManagementImageLst;
        }


        public ActionResult OpenLitigationAssetUpload()
        {
            return PartialView("~/Views/Image/PartialOpenLitigationAssetUpload.cshtml");
        }

        public void OpenLitigationAssetUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "litigationAsset";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["litigationAssetImageLst"] == null)
                        {
                            litigationAssetImageLst.Add(imgObj);
                        }
                        else
                        {
                            litigationAssetImageLst = (List<ImageDetails>)HttpContext.Session["litigationAssetImageLst"];
                            litigationAssetImageLst.Add(imgObj);
                        }

                        HttpContext.Session["litigationAssetImageLst"] = litigationAssetImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveLitigationAssetUploadedFile(string fileName)
        {
            litigationAssetImageLst = (List<ImageDetails>)HttpContext.Session["litigationAssetImageLst"];

            foreach (var i in litigationAssetImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    litigationAssetImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["litigationAssetImageLst"] = litigationAssetImageLst;
        }


        public ActionResult OpenGeoStampedUpload()
        {
            return PartialView("~/Views/Image/PartialOpenGeoStampedUpload.cshtml");
        }

        public void OpenGeoStampedUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "geoStamped";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        if (HttpContext.Session["geoStampedImageLst"] == null)
                        {
                            geoStampedImageLst.Add(imgObj);
                        }
                        else
                        {
                            geoStampedImageLst = (List<ImageDetails>)HttpContext.Session["geoStampedImageLst"];
                            geoStampedImageLst.Add(imgObj);
                        }

                        HttpContext.Session["geoStampedImageLst"] = geoStampedImageLst;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveGeoStampedUploadedFile(string fileName)
        {
            geoStampedImageLst = (List<ImageDetails>)HttpContext.Session["geoStampedImageLst"];

            foreach (var i in geoStampedImageLst)
            {
                if (i.fileName.Equals(fileName))
                {
                    geoStampedImageLst.Remove(i);
                    break;
                }
            }
            HttpContext.Session["geoStampedImageLst"] = geoStampedImageLst;
        }


        public ActionResult OpenManagementUploadFileSave()
        {
            return PartialView("~/Views/Image/PartialOpenManagementUploadFileSave.cshtml");
        }

        public void ManagementUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "managementStamped";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        //if (HttpContext.Session["managementImageLst"] == null)
                        //{
                        //    managementImageLst.Add(imgObj);
                        //}
                        //else
                        //{
                        //    managementImageLst = (List<ImageDetails>)HttpContext.Session["managementImageLst"];
                        //    managementImageLst.Add(imgObj);
                        //}

                        HttpContext.Session["managementImageLst"] = imgObj;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveManagementUploadedFile(string fileName)
        {
            //managementImageLst = (List<ImageDetails>)HttpContext.Session["managementImageLst"];

            //foreach (var i in managementImageLst)
            //{
            //    if (i.fileName.Equals(fileName))
            //    {
            //        managementImageLst.Remove(i);
            //        break;
            //    }
            //}
            HttpContext.Session["managementImageLst"] = null;
        }


        public ActionResult OpenAdvisoryUploadFileSave()
        {
            return PartialView("~/Views/Image/PartialOpenAdvisoryUploadFileSave.cshtml");
        }

        public void AdvisoryUploadFileSave()
        {

            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        int length = file.ContentLength;
                        byte[] pic = new byte[length];

                        file.InputStream.Read(pic, 0, length);

                        ImageDetails imgObj = new ImageDetails();
                        imgObj.fileName = fName;
                        imgObj.imageType = "advisoryStamped";
                        imgObj.imageContent = pic;
                        imgObj.imageSize = length;
                        //if (HttpContext.Session["managementImageLst"] == null)
                        //{
                        //    managementImageLst.Add(imgObj);
                        //}
                        //else
                        //{
                        //    managementImageLst = (List<ImageDetails>)HttpContext.Session["managementImageLst"];
                        //    managementImageLst.Add(imgObj);
                        //}

                        HttpContext.Session["advisoryImageLst"] = imgObj;

                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveAdvisoryUploadFile(string fileName)
        {
            //managementImageLst = (List<ImageDetails>)HttpContext.Session["managementImageLst"];

            //foreach (var i in managementImageLst)
            //{
            //    if (i.fileName.Equals(fileName))
            //    {
            //        managementImageLst.Remove(i);
            //        break;
            //    }
            //}
            HttpContext.Session["managementImageLst"] = null;
        }


    }
}