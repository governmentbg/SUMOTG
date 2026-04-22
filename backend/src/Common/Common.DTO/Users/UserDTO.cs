/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

namespace Common.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string role { get; set; }
        public int roleid { get; set; }
        public int scopeid { get; set; }
        public string raionid { get; set; }
        public short status { get; set; }
        public string password { get; set; }

        public AddressDTO Address { get; set; }

        public SettingsDTO Settings { get; set; }
    }
}
