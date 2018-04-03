//
// Authors:
//   Alan McGovern alan.mcgovern@gmail.com
//   Ben Motmans <ben.motmans@gmail.com>
//
// Copyright (C) 2006 Alan McGovern
// Copyright (C) 2007 Ben Motmans
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


namespace Mono.Nat
open System;
type Mapping (protocol, privatePort, publicPort, ?lifetime) =

        member val Description = "" with get, set
        member this.protocol = protocol;
        member this.privatePort = privatePort;
        member this.publicPort = publicPort;
        member this.lifetime = defaultArg lifetime 0;
        member this.expiration = 
            if (this.lifetime = Int32.MaxValue) then
                DateTime.MaxValue;
            elif (this.lifetime = 0) then
                DateTime.Now;
            else
                DateTime.Now.AddSeconds (double this.lifetime);
        member this.IsExpired () =
            this.expiration < DateTime.Now
    
   // public override bool Equals (object obj)
    //{
   //     Mapping other = obj as Mapping;
   //     return other == null ? false : this.protocol == other.protocol &&
   //         this.privatePort == other.privatePort && this.publicPort == other.publicPort;
   // }

    //public override int GetHashCode()
    //{
    //    return this.protocol.GetHashCode() ^ this.privatePort.GetHashCode() ^ this.publicPort.GetHashCode();
    //}

    //public override string ToString( )
    //{
    //    return String.Format( "Protocol: {0}, Public Port: {1}, Private Port: {2}, Description: {3}, Expiration: {4}, Lifetime: {5}", 
    //        this.protocol, this.publicPort, this.privatePort, this.description, this.expiration, this.lifetime );
    //}
