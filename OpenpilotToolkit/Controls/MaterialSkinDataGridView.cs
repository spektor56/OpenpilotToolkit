using MaterialSkin;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public class MaterialSkinDataGridView : DataGridView, IMaterialControl
    {
        public MaterialSkinDataGridView()
        {
            SkinManager.ColorSchemeChanged += sender =>
            {
                SetStyle();
            };

            SkinManager.ThemeChanged += sender =>
            {
                SetStyle();
            };
                        
            var columnHeaderBorder = AdvancedColumnHeadersBorderStyle;

            EnableHeadersVisualStyles = false;
            BorderStyle = BorderStyle.None;
            RowHeadersVisible = false;
            AutoGenerateColumns = false;
            
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ColumnHeadersHeight = RowTemplate.Height;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            columnHeaderBorder.Left = DataGridViewAdvancedCellBorderStyle.None;
            columnHeaderBorder.Right = DataGridViewAdvancedCellBorderStyle.None;
            columnHeaderBorder.Top = DataGridViewAdvancedCellBorderStyle.None;

            SetStyle();
        }

        private void SetStyle()
        {
            var gridColour = ColorHelper.RemoveAlpha(SkinManager.DividersColor, SkinManager.BackgroundColor);
            GridColor = gridColour;
            BackgroundColor = SkinManager.BackgroundColor;
            Font = SkinManager.getFontByType(MaterialSkinManager.fontType.Subtitle1);
            ForeColor = SkinManager.TextHighEmphasisColor;

            DefaultCellStyle.ForeColor = SkinManager.TextMediumEmphasisColor;
            DefaultCellStyle.BackColor = SkinManager.BackgroundColor;
            DefaultCellStyle.SelectionBackColor = SkinManager.ColorScheme.AccentColor;

            ColumnHeadersDefaultCellStyle.BackColor = SkinManager.BackgroundColor;
            ColumnHeadersDefaultCellStyle.ForeColor = SkinManager.TextHighEmphasisColor;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = SkinManager.BackgroundColor;
        }
  

        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;

        [Browsable(false)]
        public MouseState MouseState { get; set; }


    }
}
