/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */
export const environment = {
  dbname: '',
  production: true,
  apiUrl: (window.location.protocol == 'https:' ? 'https://heatersapi.sofia.bg:443/api' :'http://172.22.4.166:5005/api'),
  testUser: {
    token: {},
    email: '',
  },
};
