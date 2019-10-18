using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{ 
    public enum ModelState : byte
    {
        None,
        Inserted,
        Updated,
        Selected,
        Deleted,
        NotInserted,
        NotUpdated,
        NotSelected,
        NotDeleted
    }
    public class BaseModel
    {
        public ModelState State { get; set; }

        public BaseModel()
        {
            State = ModelState.None;
        }

        public override string ToString()
        {
            return State + "";
        }
    }
}
