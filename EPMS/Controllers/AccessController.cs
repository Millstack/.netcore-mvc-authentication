﻿using Microsoft.AspNetCore.Mvc;
            // checking if user is still logged in
            ClaimsPrincipal claimUser = HttpContext.User;
            {
                return RedirectToAction("Index", "Home");
            }
            {
                List<Claim> claims = new List<Claim>()
                {
                    // creating a new claim
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties", "Eg - Role, for role based authorization")

                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }