﻿using System.Collections.Generic;

using Core.DataTransferObjects.RabbitMQ;

using Newtonsoft.Json;

namespace Client.Services
{
    public class FileService : Interfaces.IFileService
    {
        // FIELDS
        private System.Net.Http.HttpClient client;

        // CONSTRUCTORS
        public FileService(System.Net.Http.HttpClient client)
        {
            this.client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        // METHODS
        public async System.Threading.Tasks.Task<IEnumerable<WorkerData>> ActionCallListAsync()
        {
            string url = string.Format(ServiceManagers.RestApiServiceManager.URL_FORMAT, $@"api/file");

            return JsonConvert.DeserializeObject<IEnumerable<WorkerData>>(await client.GetStringAsync(url));
        }
    }
}
