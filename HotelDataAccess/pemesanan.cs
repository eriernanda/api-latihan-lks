//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class pemesanan
    {
        public int no_reservasi { get; set; }
        public int id_pelanggan { get; set; }
        public int no_kamar { get; set; }
        public Nullable<System.DateTime> checkin { get; set; }
        public Nullable<System.DateTime> checkout { get; set; }
        public Nullable<int> total { get; set; }
    }
}
