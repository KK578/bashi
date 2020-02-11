// Copyright 2019-2020 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bashi.Identity.Server.Controllers
{
    /// <summary>
    /// Test controller for checking authorization.
    /// </summary>
    [Route("Identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        /// <summary>
        /// Gets the current user's available claims.
        /// </summary>
        /// <returns>JSON Response containing the current user's available claims.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(this.User.Claims.Select(x => new { x.Type, x.Value }));
        }
    }
}
