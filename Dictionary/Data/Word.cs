//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dictionary.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Word
    {
        public string word_o { get; set; }
        public int type_id { get; set; }
        public string word_m { get; set; }
    
        public virtual Type Type { get; set; }
    }
}
