// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using System.Security.Claims;
using Duende.IdentityServer.Test;
using IdentityModel;

namespace Onyx.IDP;

public static class TestUsers
{
    public static List<TestUser> Users => new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
            Username = "user1",
            Password = "password123",

            Claims = new List<Claim>
            {
                new Claim("role", "PublicUser"),
                new Claim(JwtClaimTypes.GivenName, "User1"),
                new Claim(JwtClaimTypes.FamilyName, "OnyxGroup")
            }
        },
        new TestUser
        {
            SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
            Username = "user2",
            Password = "password345",

            Claims = new List<Claim>
            {
                new Claim("role", "Admin"),
                new Claim(JwtClaimTypes.GivenName, "User2"),
                new Claim(JwtClaimTypes.FamilyName, "OnyxGroup")
            }
        }
    };
}