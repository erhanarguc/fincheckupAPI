using DevExpress.XtraGauges.Core.Base;
using DevExpress.XtraGauges.Core.Customization;
using DevExpress.XtraGauges.Core.Drawing;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace fincheckup.Report
{
    public partial class ReportFinancialdynamicd : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportFinancialdynamicd()
        {
            InitializeComponent();
        }
        private void xrGauge1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRGauge gauge = (XRGauge)sender;
            IDashboardGauge gaugeControl = gauge.Gauge;
            var gaugeElements = gaugeControl.Elements;

            LinearScale linearScale = GetOrAdd<LinearScale>(gaugeElements);
            SetupLinearScale(linearScale);

            LinearScaleRangeBar rangeBar = GetOrAdd<LinearScaleRangeBar>(gaugeElements);
            SetupRangeBar(rangeBar);
        }
        static T GetOrAdd<T>(List<ISerizalizeableElement> elements) where T :
             ISerizalizeableElement, new()
        {
            var element = elements.OfType<T>().FirstOrDefault();
            if (element != null) return element;

            T newElement = new T();
            elements.Add(newElement);
            return newElement;
        }



        private void SetupLinearScaleRbr(LinearScaleRangeBar linearScalelvl)
        {
            linearScalelvl.BeginUpdate();

            linearScalelvl.LinearScale.Appearance.Brush = new SolidBrushObject(Color.Transparent);



            linearScalelvl.Appearance.ContentBrush = new SolidBrushObject(Color.Transparent);



            linearScalelvl.EndUpdate();
        }
        private void SetupLinearScalelvl(LinearScaleLevel linearScalelvl)
        {
            linearScalelvl.BeginUpdate();



            linearScalelvl.BarEmptyShape.Appearance.ContentBrush = new SolidBrushObject(Color.Transparent);



            linearScalelvl.EndUpdate();
        }

        static void SetupLinearScale(LinearScale linearScale)
        {
            linearScale.BeginUpdate();

            AddScaleRanges(linearScale);
            linearScale.MinValue = 1;
            linearScale.MaxValue = 8;

            linearScale.Appearance.Brush = new SolidBrushObject(Color.Transparent);

            linearScale.MinorTickmark.ShowTick = false;
            linearScale.MajorTickmark.ShowTick = false;
            linearScale.MajorTickmark.ShowText = true;

            linearScale.EndUpdate();
        }

        static void SetupRangeBar(LinearScaleRangeBar rangeBar)
        {
            rangeBar.Appearance.ContentBrush = new SolidBrushObject(Color.Transparent);
        }

        static void AddMarker(DashboardGauge gauge, float value)
        {
            LinearScaleProvider linearScaleComponent1 = gauge.Scale as LinearScaleProvider;
            LinearScaleMarker marker = new LinearScaleMarker("marker");
            marker.ShapeType = MarkerPointerShapeType.Circle;
            marker.Shader = new StyleShader() { StyleColor1 = Color.Black, StyleColor2 = Color.Blue };
            marker.ShapeOffset = -20.0f;
            marker.Value = value;
            marker.LinearScale = linearScaleComponent1;
            ModelRoot root = gauge.Model.Composite[PredefinedCoreNames.LinearGaugeRotationNode] as ModelRoot;
            root.Composite.Add(marker);
        }

        static void AddScaleRanges(LinearScale scale)
        {
            LinearScaleRange range1 = new LinearScaleRange();
            range1.AppearanceRange.ContentBrush = new SolidBrushObject(Color.FromArgb(182, 33, 45));
            range1.StartValue = 1;
            range1.EndValue = 1.8f;

            LinearScaleRange range2 = new LinearScaleRange();
            range2.AppearanceRange.ContentBrush = new SolidBrushObject(Color.FromArgb(182, 119, 33));
            range2.StartValue = 1.8f;
            range2.EndValue = 3;

            LinearScaleRange range3 = new LinearScaleRange();
            range3.AppearanceRange.ContentBrush = new SolidBrushObject(Color.FromArgb(23, 127, 117));
            range3.StartValue = 3;
            range3.EndValue = 8;

            scale.Ranges.Clear();
            scale.Ranges.AddRange(new IRange[] { range1, range2, range3 });
        }

    }
}
