#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.File
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BulkDeletionResultMapper : IObjectMapper<BulkDeleteResponse, BulkDeletionResults>
    {
        private readonly IStatusParser _statusParser;

        public BulkDeletionResultMapper(IStatusParser statusParser)
        {
            _statusParser = statusParser;
        }

        /// <inheritdoc/>
        public BulkDeletionResults Map(BulkDeleteResponse from)
        {
            var successfulObjects = from.AllItems.Where(i => !from.IsItemError(i));
            var failedObjects = from.Errors.Select(e =>
            {
                var eParts = e.ToArray();
                Status errorStatus;
                string errorItem;

                if (eParts.Length != 2)
                {
                    errorStatus = new Status(0, "Unknown");
                    errorItem = string.Format("The error array has an unexpected length. Array: {0}", string.Join("||", eParts));
                }
                else
                {
                    errorItem = eParts[1];
                    if (!_statusParser.TryParse(eParts[0], out errorStatus))
                    {
                        errorItem = eParts[0];
                        if (!_statusParser.TryParse(eParts[1], out errorStatus))
                        {
                            errorStatus = new Status(0, "Unknown");
                            errorItem = string.Format("The error array is in an unknown format. Array: {0}", string.Join("||", eParts));
                        }
                    }
                }

                return new BulkDeletionFailedObject(errorItem, errorStatus);
            });

            return new BulkDeletionResults(successfulObjects, failedObjects);
        }

        /// <inheritdoc/>
        public BulkDeleteResponse Map(BulkDeletionResults to)
        {
            throw new NotImplementedException();
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BulkDeleteResponse
    {
        [JsonProperty("Number Not Found")]
        public int NumberNotFound { get; set; }

        [JsonProperty("Response Status")]
        public string Status { get; set; }

        [JsonProperty("Errors")]
        public IEnumerable<IEnumerable<string>> Errors { get; set; }

        [JsonProperty("Number Deleted")]
        public int NumberDeleted { get; set; }

        [JsonProperty("Response Body")]
        public string ResponseBody { get; set; }

        public IEnumerable<string> AllItems { get; set; }

        public bool IsItemError(string s)
        {
            return Errors.Any(e => e.Any(e2 => e2.Equals(s)));
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member