using System;

namespace the_wall_api
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        //this might need to change to string
        public int ExpirationInMinutes { get; set; }
    }
}
