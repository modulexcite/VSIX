// Guids.cs
// MUST match guids.h
using System;

namespace ObjectNET.Bridge_NET
{
    static class GuidList
    {
        public const string guidBridge_NETPkgString = "35c8bcc7-192f-44c1-ba39-20a9ffcdddb0";
        public const string guidBridge_NETCmdSetString = "fe5f1ecd-692d-41ea-8be7-8faf97dd20af";

        public static readonly Guid guidBridge_NETCmdSet = new Guid(guidBridge_NETCmdSetString);
    };
}