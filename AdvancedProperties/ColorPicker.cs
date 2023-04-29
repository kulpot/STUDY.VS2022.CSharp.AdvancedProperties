using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedProperties
{
    class ColorPicker : Control
    {
        private Color _pickedColor = Color.Black;
        public event EventHandler PickedColorChanged;

        protected virtual void OnPickedColorChanged()
        {
            if(PickedColorChanged != null)
                PickedColorChanged(this, EventArgs.Empty);
        }

        /// <summary>
        ///  Gets or Sets the picked color :) 
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Category("Input")]
        [DisplayName("~~~~Picked Color~~~~")]
        [Description("*****The color that has been picked*****")]
        //[Obsolete("This is old!", false)]
        //[Localizable(true)]//if properties is string, means that diff. states of properties for diff. locals
        //[RefreshProperties(System.ComponentModel.RefreshProperties.All)]
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PickedColor
        {
            get { return _pickedColor; }
            set
            {
                if (value == Color.Transparent && value == Color.Magenta)
                {
                    return;
                }

                bool changed = value != _pickedColor;
                _pickedColor = value;

                if (changed)
                    OnPickedColorChanged();
            }
        }
    }
}
