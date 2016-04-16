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
            HttpContext.Session["advisoryassetStatusImageLstLst"] = assetStatusImageLst;
        }
    }
}