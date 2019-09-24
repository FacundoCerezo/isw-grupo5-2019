using MimeTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Realizar_Pedido_de_lo_que_sea.Controllers
{
	
	// Anotación para controlar que el tamaño del archivo subido no sea mayor
	// a cierta cantidad en bytes.
	public class MaxContentLengthAttribute : AuthorizationFilterAttribute
	{
		private readonly long _maxContentType;

		public MaxContentLengthAttribute(long maxContentType)
		{
			_maxContentType = maxContentType;
		}

		public override void OnAuthorization(HttpActionContext actionContext)
		{
			var contentLength = actionContext.Request.Content.Headers.ContentLength;
			if (contentLength.HasValue && contentLength.Value > _maxContentType)
			{
				actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.RequestEntityTooLarge, "El archivo es demasiado grande. Sube un archivo menor a "+_maxContentType/1024/1024+"MB");
			}
		}
	}

	[RoutePrefix("api/uploads")]
	public class UploadsController : ApiController
	{
		// Tamaño máximo de archivo (5MB default)
		const Int32 MAX_FILE_SIZE = 1024 * 1024 * 5;

		[MaxContentLength(MAX_FILE_SIZE)]
		[Route("")]
		public HttpResponseMessage Post()
		{
			var httpRequest = HttpContext.Current.Request;
			String finalFileName = "";
			if (httpRequest.Files.Count < 1)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			foreach (string file in httpRequest.Files)
			{
				var postedFile = httpRequest.Files[file];
				var fileName = DateTime.Now.ToFileTime();
				var fileExt = MimeTypeMap.GetExtension(postedFile.ContentType);
				if (!fileExt.ToString().Contains(".jp") && !fileExt.ToString().Equals(".png") && !fileExt.ToString().Equals(".gif"))
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "extensión inválida");
				}
				finalFileName = fileName + fileExt;
				var filePath = HttpContext.Current.Server.MapPath("~/App_Data/Uploads/" + finalFileName);
				postedFile.SaveAs(filePath);
				// NOTE: To store in memory use postedFile.InputStream
			}

			return Request.CreateResponse(HttpStatusCode.Created, (finalFileName));
		}

		[Route("{Name}")]
		public HttpResponseMessage Get(String Name)
		{
			var result = new HttpResponseMessage(HttpStatusCode.OK);
			String filePath = HttpContext.Current.Server.MapPath("~/App_Data/Uploads/" + Name);

			if (!System.IO.File.Exists(filePath))
			{
				HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotFound);
				return res;
			}

			HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
			FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			String mime = MimeTypeMap.GetMimeType(Path.GetExtension(Name));
			response.Content = new StreamContent(stream);
			response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mime);
			return response;
		}
	}
}
