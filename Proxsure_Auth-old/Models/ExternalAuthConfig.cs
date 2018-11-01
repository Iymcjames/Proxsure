namespace Proxsure_Auth.Models {
    public class ExternalAuthConfig {
        public Credentials GoogleCredentials { get; set; }
        public Credentials FacebookCredentials { get; set; }

    }

    public class Credentials {
        public string Id { get; set; }
        public string Secret { get; set; }
    }
}