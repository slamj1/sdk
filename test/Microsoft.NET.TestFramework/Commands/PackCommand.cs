// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using Microsoft.DotNet.Cli.Utils;
using System.IO;
using Xunit.Abstractions;

namespace Microsoft.NET.TestFramework.Commands
{
    public sealed class PackCommand : MSBuildCommand
    {
        public PackCommand(ITestOutputHelper log, string projectPath, string relativePathToProject = null, MSBuildTest msbuild = null)
            : base(log, "Pack", projectPath, relativePathToProject, msbuild)
        {
        }

        public string GetIntermediateNuspecPath(string packageId = null, string packageVersion = "1.0.0")
        {
            if (packageId == null)
            {
                packageId = Path.GetFileNameWithoutExtension(ProjectFile);
            }

            return Path.Combine(GetBaseIntermediateDirectory().FullName, $"{packageId}.{packageVersion}.nuspec");
        }
    }
}
