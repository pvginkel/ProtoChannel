﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace ProtoChannel.Web
{
    internal class StreamUploadRequest : Request
    {
        private readonly ProtoProxyClient _client;
        private readonly int _associationId;

        public StreamUploadRequest(HttpContext context, AsyncCallback asyncCallback, object extraData, ProtoProxyClient client, int associationId)
            : base(context, asyncCallback, extraData)
        {
            Require.NotNull(client, "client");

            _client = client;
            _associationId = associationId;

            _client.Touch();

            HandleRequest();

            SetAsCompleted(null, true);
        }

        private void HandleRequest()
        {
            if (Context.Request.Files.Count != 1)
                throw new HttpException("Expected exactly one file upload");

            var file = Context.Request.Files[0];

            int associationId = _client.Client.SendStream(file.InputStream, file.FileName, file.ContentType, _associationId);

            Debug.Assert(_associationId == associationId);
        }
    }
}
