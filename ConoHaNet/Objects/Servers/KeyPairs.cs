#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Servers
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListKeypairsResponse
    {
        [JsonProperty("keypairs", DefaultValueHandling = DefaultValueHandling.Include)]
        public KeypairData[] Keypairs { get; set; }
    }


    public class KeypairData : ExtensibleJsonObject
    {
        [JsonProperty("keypair", DefaultValueHandling = DefaultValueHandling.Include)]
        public Keypair KeyPair { get; set; }
    }

    public class Keypair : ExtensibleJsonObject
    {

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("public_key", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string PublicKey { get; set; }

        [JsonProperty("private_key", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateKey { get; set; }

        [JsonProperty("fingerprint", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string FingerPrint { get; set; }

        [JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class AddKeypairRequest
    {
        [JsonProperty("keypair", DefaultValueHandling = DefaultValueHandling.Include)]
        public Keypair keypair { get; internal set; }

        public AddKeypairRequest(string name, string publickey)
        {
            this.keypair = new Keypair()
            {
                Name = name,
                PublicKey = publickey
            };
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class AddKeypairResponse
    {
        [JsonProperty("keypair", DefaultValueHandling = DefaultValueHandling.Include)]
        public Keypair Keypair { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetKeypairResponse
    {
        [JsonProperty("keypair", DefaultValueHandling = DefaultValueHandling.Include)]
        public Keypair Keypair { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member