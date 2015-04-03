using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.AgInfiniium90000AQX_04_60_0016;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;


namespace jitterVals2
{





    public partial class Form1 : Form
    {
        string instrumentAddress = "TCPIP0::127.0.0.1::inst0::INSTR";
        //  Auction test1 = new Auction();
        public Form1()
        {
            InitializeComponent();
            getGoing();
            //  test1.auctionID = "contents sale";
            //Console.WriteLine(test1.auctionID);
            System.Threading.Thread.Sleep(2000);
            

        }

        private void getGoing()
        {
            const int elementCount=34;
     arraylist.array2Db = new string[ elementCount, 3]{
    	   {"Mode"                 , " " ,   " "},
           {"Edge"                 , " " ,   " "},
           {"Bandwidth"            , " " ,   " "},
           {"Units"                , " " ,   " "},
           {"Method"               , " " ,   " "},
           {"Report"               , " " ,   " "},
           {"Source"               , " " ,   " "},
           {"BER"                  , " " ,   " "},
           {"Period Length"        , " " ,   " "},
           {"Noise Enable"         , " " ,   " "},
           {"RN bandwidth"         , " " ,   " "},
           {"RN Meas location"     , " " ,   " "},
           {"RN units1"            , " " ,   " "},
           {"RN method"            , " " ,   " "},
           {"RN report"            , " " ,   " "},
           {"clock"                , " " ,   " "},
           {"Filter TIE"           , " " ,   " "},
           {"Filter type"          , " " ,   " "},
           {"start_frequency"      , " " ,   " "},
           {"stop_frequency"       , " " ,   " "},
           {"shape"                , " " ,   " "},
           {"RJ Setting"           , " " ,   " "},
           {"RN Setting"           , " " ,   " "},
           {"JTF clockMethod"      , " " ,   " "},
           {"OJTF clockMethod"     , " " ,   " "},
           {"align"                , " " ,   " "},
           {"DeEmphasis Removal"   , " " ,   " "},
           {"Deemphasis Edges"     , " " ,   " "},
           {"method2"              , " " ,   " "},
           {"lower_pct"            , " " ,   " "},
           {"lower_volts"          , " " ,   " "},
           {"level"                , " " ,   " "},
           {"method3"              , " " ,   " "},
           {"base_volts"           , " " ,   " "}
			};

     dataGridView1.Rows.Clear();
     dataGridView1.Refresh();

     dataGridView1.ColumnCount = 4;
     dataGridView1.Columns[0].Name = "Variable name";
     dataGridView1.Columns[1].Name = "Value";
     dataGridView1.Columns[2].Name = "Frozen Value";
     dataGridView1.Columns[3].Name = "Difference?";

            for (int i = 0; i < elementCount; i++)
            {
                string[] row = new string[] { arraylist.array2Db[i, 0], arraylist.array2Db[i, 1], arraylist.array2Db[i, 2] };
                dataGridView1.Rows.Add(row);
            }

        }
        private string GetDivElements()
        {
            // Initialize StringWriter instance.
            StringWriter stringWriter = new StringWriter();

            // Put HtmlTextWriter in using block because it needs to call Dispose.
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {

                // Get the Data from the listbox
                // copy listbox items into an array for report use
                // very verbose way of doing it but it works!
                string[] arrayJitterKey = new string[listBox2.Items.Count];

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    object s = listBox2.Items[i];
                    arrayJitterKey[i] = s.ToString();
                }
                string[] arrayJitterValue = new string[listBox1.Items.Count];

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    object s = listBox1.Items[i];
                    arrayJitterValue[i] = s.ToString();
                }
                //**************************

                string[] jitterMeasurments = new string[listBox5.Items.Count];

                for (int i = 0; i < listBox5.Items.Count; i++)
                {
                    object s = listBox5.Items[i];
                    jitterMeasurments[i] = s.ToString();
                }


                // Some strings for the attributes.
                string classValue = "ClassName";

                string imageValue = @"C:\Users\Public\Documents\Infiniium\screenshot1.png";
                string pageTitle = "Jitter Capture Tool";
                string pageHeader = "Keysight Technologies";
                string lineout = " ";


                // The important part:
                writer.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
                writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1

                // Add style attribute for 'p'(paragraph) element.
                writer.AddStyleAttribute("font-size", "48pt");
                writer.AddStyleAttribute("color", "red");
                // Output the 'p' (paragraph) element with the style attributes.
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write(pageTitle);
                writer.RenderEndTag();
                // Add style attribute for 'p'(paragraph) element.
                writer.AddStyleAttribute("font-size", "12pt");
                writer.AddStyleAttribute("color", "red");
                // Output the 'p' (paragraph) element with the style attributes.
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write(pageHeader);
                writer.RenderEndTag();

                writer.AddStyleAttribute("font-size", "14pt");
                writer.AddStyleAttribute("color", "Black");
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.Write("Jitter Measurement Setup:");
                writer.RenderEndTag();

                //----------setup info -----
                // Add style attribute for 'p'(paragraph) element.
                writer.AddStyleAttribute("font-size", "10pt");
                writer.AddStyleAttribute("color", "Black");
                // Output the 'p' (paragraph) element with the style attributes.
                writer.RenderBeginTag(HtmlTextWriterTag.P);

                for (int i = 0; i < listBox2.Items.Count; i++)
                {

                    lineout = arrayJitterKey[i] + ' ' + arrayJitterValue[i] + " | " + "\n";// this new line is for readability of html
                    //writer.RenderBeginTag(HtmlTextWriterTag.P);
                    writer.Write(lineout);
                    // writer.RenderEndTag();
                }
                writer.RenderEndTag();
                //------------------




                for (int i = 0; i < listBox5.Items.Count; i++)
                {

                    lineout = jitterMeasurments[i] + "\n";// this new line is for readability of html
                    writer.RenderBeginTag(HtmlTextWriterTag.P);
                    writer.Write(lineout);
                    writer.RenderEndTag();

                }


                //--------------------------------

                writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #2


                writer.AddAttribute(HtmlTextWriterAttribute.Src, imageValue);
                writer.AddAttribute(HtmlTextWriterAttribute.Width, "1024");
                writer.AddAttribute(HtmlTextWriterAttribute.Height, "768");
                writer.AddAttribute(HtmlTextWriterAttribute.Alt, "");

                writer.RenderBeginTag(HtmlTextWriterTag.Img); // Begin #3
                writer.RenderEndTag(); // End #3

                //                   writer.Write(word);

                writer.RenderEndTag(); // End #2
                writer.RenderEndTag(); // End #1
                //               }
            }
            // Return the result.
            return stringWriter.ToString();
        }

        private void listBox1_CollectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = instrumentAddress;
            getJitVals();




        }
        public void getJitVals()
        {
            string mode = null;
            string edge = null;
            string bandwidth = null;
            string units = null;
            string method = null;
            string report = null;
            string source = null;
            string ber = null;
            string plength = null;
            bool state = false;
            string bandwidth1 = null;
            double location = 0;
            string units1 = null;
            string method1 = null;
            string report1 = null;
            bool clock = false;
            bool state1 = false;
            string type = null;
            double start_frequency = 0;
            double stop_frequency = 0;
            string shape = null;
            string rjSetting = null;
            string rnSetting = null;
            string clockmethod = null;
            string clockMethod = null;
            string clockMethod1 = null;
            string align = null;
            bool state2 = false;
            string edge1 = null;
            string method2 = null;
            double upper_pct = 0;
            double middle_pct = 0;
            double lower_pct = 0;
            double upper_volts = 0;
            double middle_volts = 0;
            double lower_volts = 0;
            double range = 0;
            double level = 0;
            string method3 = null;
            double top_volts = 0;
            double base_volts = 0;
            string all = null;
            double aplength = 0;

            // In order to use below driver class, you need to reference this assembly : [C:\ProgramData\Agilent\Command Expert\ScpiNetDrivers\AgInfiniium90000AQX_04_60_0016.dll]
            // AgInfiniium90000AQX Localhost = new AgInfiniium90000AQX("TCPIP0::localhost::inst0::INSTR");
            AgInfiniium90000AQX Localhost = new AgInfiniium90000AQX(instrumentAddress);

            Localhost.SCPI.MEASure.RJDJ.MODE.Query(out mode);
            Localhost.SCPI.MEASure.RJDJ.EDGE.Query(out edge);
            Localhost.SCPI.MEASure.RJDJ.BANDwidth.Query(out bandwidth);
            // ---> "Number of UI" the number will show up in the rjdj mode if nui selected and returned
            Localhost.SCPI.MEASure.RJDJ.UNITs.Query(out units);
            Localhost.SCPI.MEASure.RJDJ.METHod.Query(out method);
            Localhost.SCPI.MEASure.RJDJ.REPort.Query(out report);
            Localhost.SCPI.MEASure.RJDJ.SOURce.Query(out source);
            Localhost.SCPI.MEASure.RJDJ.BER.Query(out ber);
            // Pattern length entry ireturns Periodic (Auto or a number) or Arbitratry returns (Arb, isi lead, lag)
            Localhost.SCPI.MEASure.RJDJ.PLENgth.Query(out plength);
            // Noise Panel
            // Comment text
            Localhost.SCPI.MEASure.NOISe.STATe.Query(out state);
            Localhost.SCPI.MEASure.NOISe.BANDwidth.Query(out bandwidth1);
            Localhost.SCPI.MEASure.NOISe.LOCation.Query(out location);
            Localhost.SCPI.MEASure.NOISe.UNITs.Query(out units1);
            Localhost.SCPI.MEASure.NOISe.METHod.Query(out method1);
            // if spectral and tailfit chosen, timeout error often occurs
            Localhost.SCPI.MEASure.NOISe.REPort.Query(out report1);
            // End of noise panel
            // Advanced Panel
            Localhost.SCPI.MEASure.RJDJ.CLOCk.Query(out clock);
            // Number of Graphs dont appear to be available along with scale settings
            // tie filter
            Localhost.SCPI.MEASure.TIEFilter.STATe.Query(out state1);
            // values are L(owpass) B(andpass) H(ighpass)
            Localhost.SCPI.MEASure.TIEFilter.TYPE.Query(out type);
            if (type == "L") type = "LowPass";
            if (type == "B") type = "BandPass";
            if (type == "H") type = "HighPass";

            Localhost.SCPI.MEASure.TIEFilter.STARt.Query(out start_frequency);
            Localhost.SCPI.MEASure.TIEFilter.STOP.Query(out stop_frequency);
            // Shape is rectangular , DB20 or DB40 n(isnt in the Tie Menu however)
            // 
            Localhost.SCPI.MEASure.TIEFilter.SHAPe.Query(out shape);
            // end of  tie filter
            // level qualifier of timing Meas. Need to research more
            // Remove Specify Jitter noise pattern
            Localhost.SCPI.MEASure.RJDJ.SCOPe.RJ.Query(out rjSetting);
            Localhost.SCPI.MEASure.NOISe.SCOPe.RN.Query(out rnSetting);

            // clock recovery panel
            Localhost.SCPI.MEASure.CLOCk.METHod.Query(out clockmethod);
            // the next 2 reads may return scpi error -221 settings conflict depending on clock method
            try
            {
                Localhost.SCPI.MEASure.CLOCk.METHod.JTF.Query(out clockMethod);
            }
            catch
            {
                clockMethod = "---";
            }
            try
            {
                Localhost.SCPI.MEASure.CLOCk.METHod.OJTF.Query(out clockMethod1);
            }
            catch
            {
                clockMethod1 = "---";
            }

            Localhost.SCPI.MEASure.CLOCk.METHod.ALIGn.Query(out align);
            Localhost.SCPI.MEASure.CLOCk.METHod.DEEMphasis.Query(out state2);
            Localhost.SCPI.MEASure.CLOCk.METHod.EDGE.Query(out edge1);
            // cannot locate transition density dependent switch in clock panel
            // start thresholds
            // the following can be source all, chan 1,2,3,4  wfm eq mtrend etc 
            Localhost.SCPI.MEASure.THResholds.GENERAL.METHod.Query("ALL", out method2);
            Localhost.SCPI.MEASure.THResholds.GENERAL.PERCent.Query("ALL", out upper_pct, out middle_pct, out lower_pct);
            Localhost.SCPI.MEASure.THResholds.GENERAL.ABSolute.Query("ALL", out upper_volts, out middle_volts, out lower_volts);
            Localhost.SCPI.MEASure.THResholds.GENERAL.HYSTeresis.Query("ALL", out range, out level);
            Localhost.SCPI.MEASure.THResholds.GENERAL.TOPBase.METHod.Query("ALL", out method3);
            Localhost.SCPI.MEASure.THResholds.GENERAL.TOPBase.ABSolute.Query("ALL", out top_volts, out base_volts);


            Localhost.SCPI.MEASure.RJDJ.ALL.Query(out all);
            Localhost.SCPI.MEASure.RJDJ.APLength.Query(out aplength);

            string[] RJDJsplit = all.Split(',');//seperate out measurements
            //they are grouped in threes that need to be kept together
            // string TJmeas =       RJDJsplit.ElementAt(0)  + "    " + RJDJsplit.ElementAt(1)  + " UI";
            // double TJmeas = Convert.ToDouble(RJDJsplit.ElementAt(1));
            string TJmeas = RJDJsplit.ElementAt(0) + "    " + Convert.ToDouble(RJDJsplit.ElementAt(1)).ToString("###.###,###,###,###,###") + " UI";
            string RJmeas = RJDJsplit.ElementAt(3) + "    " + RJDJsplit.ElementAt(4) + " UI";
            string DJddmeas = RJDJsplit.ElementAt(6) + "    " + RJDJsplit.ElementAt(7) + " UI";
            string PJmeas = RJDJsplit.ElementAt(9) + "    " + RJDJsplit.ElementAt(10) + " UI";
            string PJddmeas = RJDJsplit.ElementAt(12) + "    " + RJDJsplit.ElementAt(13) + " UI";
            string DDJmeas = RJDJsplit.ElementAt(15) + "    " + RJDJsplit.ElementAt(16) + " UI";
            string DCDmeas = RJDJsplit.ElementAt(18) + "    " + RJDJsplit.ElementAt(19) + " UI";
            string ISImeas = RJDJsplit.ElementAt(21) + "    " + RJDJsplit.ElementAt(22) + " UI";
            string Transmeas = RJDJsplit.ElementAt(24) + "    " + RJDJsplit.ElementAt(25) + " ";
            string DDPWSmeas = RJDJsplit.ElementAt(27) + "    " + RJDJsplit.ElementAt(28) + " UI";

            double someMoneyVar = Convert.ToDouble(RJDJsplit.ElementAt(1));


            //foreach (string i in RJDJsplit)
            //{ listBox5.Items.Add(i); }

            listBox5.Items.Clear();
            listBox5.Items.Add(TJmeas);
            listBox5.Items.Add(RJmeas);
            listBox5.Items.Add(DJddmeas);
            listBox5.Items.Add(PJmeas);
            listBox5.Items.Add(PJddmeas);
            listBox5.Items.Add(DDJmeas);
            listBox5.Items.Add(DCDmeas);
            listBox5.Items.Add(ISImeas);
            listBox5.Items.Add(Transmeas);
            listBox5.Items.Add(DDPWSmeas);



            /* Console.WriteLine("mode " + mode);
             Console.WriteLine("edge " + edge);
             Console.WriteLine("bandwidth " + bandwidth);
             Console.WriteLine("units" + units);
 */
            listBox1.Items.Clear();
            listBox1.Items.Add(mode);
            listBox1.Items.Add(edge);
            listBox1.Items.Add(bandwidth);
            listBox1.Items.Add(units);
            listBox1.Items.Add(method);
            listBox1.Items.Add(report);
            listBox1.Items.Add(source);
            listBox1.Items.Add(ber);
            listBox1.Items.Add(plength);

            listBox1.Items.Add(state);
            listBox1.Items.Add(bandwidth1);
            listBox1.Items.Add(location);
            listBox1.Items.Add(units1);
            listBox1.Items.Add(method1);
            listBox1.Items.Add(report1);

            listBox1.Items.Add(clock);
            listBox1.Items.Add(state1);
            listBox1.Items.Add(type);
            listBox1.Items.Add(start_frequency);
            listBox1.Items.Add(stop_frequency);
            listBox1.Items.Add(shape);
            listBox1.Items.Add(rjSetting);
            listBox1.Items.Add(rnSetting);

            listBox1.Items.Add(clockMethod);
            listBox1.Items.Add(clockMethod1);
            listBox1.Items.Add(align);
            listBox1.Items.Add(state2);
            listBox1.Items.Add(edge1);
            listBox1.Items.Add(method2);
            listBox1.Items.Add(lower_pct);
            listBox1.Items.Add(lower_volts);
            listBox1.Items.Add(level);
            listBox1.Items.Add(method3);
            listBox1.Items.Add(base_volts);


            // main jittter headings
            listBox2.Items.Clear();
            listBox2.Items.Add("Mode");
            listBox2.Items.Add("Edge");
            listBox2.Items.Add("Bandwidth");
            listBox2.Items.Add("Units");
            listBox2.Items.Add("Method");
            listBox2.Items.Add("Report");
            listBox2.Items.Add("Source");
            listBox2.Items.Add("BER");
            listBox2.Items.Add("Period Length");
            //noise panel
            listBox2.Items.Add("Noise Enable");
            listBox2.Items.Add("RN bandwidth");
            listBox2.Items.Add("RN Meas location");
            listBox2.Items.Add("RN units1");
            listBox2.Items.Add("RN method");
            listBox2.Items.Add("RN report");

            listBox2.Items.Add("clock");
            listBox2.Items.Add("Filter TIE");
            listBox2.Items.Add("Filter type");
            listBox2.Items.Add("start_frequency");
            listBox2.Items.Add("stop_frequency");
            listBox2.Items.Add("shape");
            listBox2.Items.Add("RJ Setting");
            listBox2.Items.Add("RN Setting");

            listBox2.Items.Add("JTF clockMethod");
            listBox2.Items.Add("OJTF clockMethod");
            listBox2.Items.Add("align");
            listBox2.Items.Add("DeEmphasis Removal");
            listBox2.Items.Add("Deemphasis Edges");
            listBox2.Items.Add("method2");
            listBox2.Items.Add("lower_pct");
            listBox2.Items.Add("lower_volts");
            listBox2.Items.Add("level");
            listBox2.Items.Add("method3");
            listBox2.Items.Add("base_volts");

            // Console.WriteLine(sstate);



            System.Threading.Thread.Sleep(500);//added for a breakpoint



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(listBox1.Items);
            listBox6.Items.Clear();
            listBox6.Items.AddRange(listBox5.Items);

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            instrumentAddress = textBox1.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = instrumentAddress;
        }

        private void SnapShot(object sender, EventArgs e)
        {
            AgInfiniium90000AQX Localhost = new AgInfiniium90000AQX(instrumentAddress);
            Localhost.SCPI.DISK.SAVE.IMAGe.Command("screenshot1", "PNG", "SCReen", null, null, null);
            // delay so file can be written
            System.Threading.Thread.Sleep(500);
            pictureBox1.ImageLocation = @"C:\Users\Public\Documents\Infiniium\screenshot1.png";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\Public\Documents\Infiniium\jitterDump.html", GetDivElements());

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1.Text = GetDivElements();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listbox1_selectedIndexChanged(Object sender, EventArgs e)
        {

            listBox2.SelectedIndex = listBox1.SelectedIndex;

        }

        private void listbox2_selectedIndexChanged(Object sender, EventArgs e)
        {

            listBox1.SelectedIndex = listBox2.SelectedIndex;

        }

        private void button9_Click(object sender, EventArgs e)
        {

            string[] itemListLive = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                object s = listBox1.Items[i];
                itemListLive[i] = s.ToString();
            }

            string[] itemListFreeze = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                object s = listBox3.Items[i];
                itemListFreeze[i] = s.ToString();
            }

            listBox4.Items.Clear();
            //check for differences
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (itemListLive[i] == itemListFreeze[i])
                {
                    listBox4.Items.Add(" - ");
                }
                else
                {
                    listBox4.Items.Add("!!diff!!");
                }

            }

        }

        public void button3_Click_1(object sender, EventArgs e)
        {

            const int elementCount = 34;


            string mode = null;
            string edge = null;
            string bandwidth = null;
            string units = null;
            string method = null;
            string report = null;
            string source = null;
            string ber = null;
            string plength = null;
            bool state = false;
            string bandwidth1 = null;
            double location = 0;
            string units1 = null;
            string method1 = null;
            string report1 = null;
            bool clock = false;
            bool state1 = false;
            string type = null;
            double start_frequency = 0;
            double stop_frequency = 0;
            string shape = null;
            string rjSetting = null;
            string rnSetting = null;
            string clockmethod = null;
            string clockMethod = null;
            string clockMethod1 = null;
            string align = null;
            bool state2 = false;
            string edge1 = null;
            string method2 = null;
            double upper_pct = 0;
            double middle_pct = 0;
            double lower_pct = 0;
            double upper_volts = 0;
            double middle_volts = 0;
            double lower_volts = 0;
            double range = 0;
            double level = 0;
            string method3 = null;
            double top_volts = 0;
            double base_volts = 0;
            string all = null;
            double aplength = 0;

            // In order to use below driver class, you need to reference this assembly : [C:\ProgramData\Agilent\Command Expert\ScpiNetDrivers\AgInfiniium90000AQX_04_60_0016.dll]
            // AgInfiniium90000AQX Localhost = new AgInfiniium90000AQX("TCPIP0::localhost::inst0::INSTR");
            AgInfiniium90000AQX Localhost = new AgInfiniium90000AQX(instrumentAddress);

            Localhost.SCPI.MEASure.RJDJ.MODE.Query(out mode);
            Localhost.SCPI.MEASure.RJDJ.EDGE.Query(out edge);
            Localhost.SCPI.MEASure.RJDJ.BANDwidth.Query(out bandwidth);
            // ---> "Number of UI" the number will show up in the rjdj mode if nui selected and returned
            Localhost.SCPI.MEASure.RJDJ.UNITs.Query(out units);
            Localhost.SCPI.MEASure.RJDJ.METHod.Query(out method);
            Localhost.SCPI.MEASure.RJDJ.REPort.Query(out report);
            Localhost.SCPI.MEASure.RJDJ.SOURce.Query(out source);
            Localhost.SCPI.MEASure.RJDJ.BER.Query(out ber);
            // Pattern length entry ireturns Periodic (Auto or a number) or Arbitratry returns (Arb, isi lead, lag)
            Localhost.SCPI.MEASure.RJDJ.PLENgth.Query(out plength);
            // Noise Panel
            // Comment text
            Localhost.SCPI.MEASure.NOISe.STATe.Query(out state);
            Localhost.SCPI.MEASure.NOISe.BANDwidth.Query(out bandwidth1);
            Localhost.SCPI.MEASure.NOISe.LOCation.Query(out location);
            Localhost.SCPI.MEASure.NOISe.UNITs.Query(out units1);
            Localhost.SCPI.MEASure.NOISe.METHod.Query(out method1);
            // if spectral and tailfit chosen, timeout error often occurs
            Localhost.SCPI.MEASure.NOISe.REPort.Query(out report1);
            // End of noise panel
            // Advanced Panel
            Localhost.SCPI.MEASure.RJDJ.CLOCk.Query(out clock);
            // Number of Graphs dont appear to be available along with scale settings
            // tie filter
            Localhost.SCPI.MEASure.TIEFilter.STATe.Query(out state1);
            // values are L(owpass) B(andpass) H(ighpass)*
            Localhost.SCPI.MEASure.TIEFilter.TYPE.Query(out type);
            if (type == "L") type = "LowPass";
            if (type == "B") type = "BandPass";
            if (type == "H") type = "HighPass";

            Localhost.SCPI.MEASure.TIEFilter.STARt.Query(out start_frequency);
            Localhost.SCPI.MEASure.TIEFilter.STOP.Query(out stop_frequency);
            // Shape is rectangular , DB20 or DB40 n(isnt in the Tie Menu however)
            // 
            Localhost.SCPI.MEASure.TIEFilter.SHAPe.Query(out shape);
            // end of  tie filter
            // level qualifier of timing Meas. Need to research more
            // Remove Specify Jitter noise pattern
            Localhost.SCPI.MEASure.RJDJ.SCOPe.RJ.Query(out rjSetting);
            Localhost.SCPI.MEASure.NOISe.SCOPe.RN.Query(out rnSetting);

            // clock recovery panel
            Localhost.SCPI.MEASure.CLOCk.METHod.Query(out clockmethod);
            // the next 2 reads may return scpi error -221 settings conflict depending on clock method
            try
            {
                Localhost.SCPI.MEASure.CLOCk.METHod.JTF.Query(out clockMethod);
            }
            catch
            {
                clockMethod = "---";
            }
            try
            {
                Localhost.SCPI.MEASure.CLOCk.METHod.OJTF.Query(out clockMethod1);
            }
            catch
            {
                clockMethod1 = "---";
            }

            Localhost.SCPI.MEASure.CLOCk.METHod.ALIGn.Query(out align);
            Localhost.SCPI.MEASure.CLOCk.METHod.DEEMphasis.Query(out state2);
            Localhost.SCPI.MEASure.CLOCk.METHod.EDGE.Query(out edge1);
            // cannot locate transition density dependent switch in clock panel
            // start thresholds
            // the following can be source all, chan 1,2,3,4  wfm eq mtrend etc 
            Localhost.SCPI.MEASure.THResholds.GENERAL.METHod.Query("ALL", out method2);
            Localhost.SCPI.MEASure.THResholds.GENERAL.PERCent.Query("ALL", out upper_pct, out middle_pct, out lower_pct);
            Localhost.SCPI.MEASure.THResholds.GENERAL.ABSolute.Query("ALL", out upper_volts, out middle_volts, out lower_volts);
            Localhost.SCPI.MEASure.THResholds.GENERAL.HYSTeresis.Query("ALL", out range, out level);
            Localhost.SCPI.MEASure.THResholds.GENERAL.TOPBase.METHod.Query("ALL", out method3);
            Localhost.SCPI.MEASure.THResholds.GENERAL.TOPBase.ABSolute.Query("ALL", out top_volts, out base_volts);


            Localhost.SCPI.MEASure.RJDJ.ALL.Query(out all);
            Localhost.SCPI.MEASure.RJDJ.APLength.Query(out aplength);
           
           // arraylist.array2Db = new string[elementCount, 3]{
           //{"Mode"              ,mode,      " "},
           //{"Edge"              ,edge,      " "},
           //{"Bandwidth"         ,bandwidth, " "},
           //{"Units"             ,units,     " "},
           //{"Method"            ,method ,   " "},
           //{"Report"            ,report ,   " "},
           //{"Source"            ,source ,   " "},
           //{"BER"               ,ber,       " "},
           //{"Period Length"     ,plength,   " "},
           //{"Noise Enable"      ,state.ToString(),      " "},
           //{"RN bandwidth"      ,bandwidth1,      " "},
           //{"RN Meas location"  ,location.ToString(),      " "},
           //{"RN units1"         ,units1,      " "},
           //{"RN method"         ,method1,      " "},
           //{"RN report"         ,report1,      " "},
           //{"clock"             ,clock.ToString(),      " "},
           //{"Filter TIE"        ,state1.ToString(),      " "},
           //{"Filter type"       ,type,      " "},
           //{"start_frequency"   ,start_frequency.ToString(),      " "},
           //{"stop_frequency"    ,stop_frequency.ToString(),      " "},
           //{"shape"             ,shape,      " "},
           //{"RJ Setting"        ,rjSetting,      " "},
           //{"RN Setting"        ,rnSetting,      " "},
           //{"JTF clockMethod"   ,clockMethod,      " "},
           //{"OJTF clockMethod"  ,clockMethod1,      " "},
           //{"align"             ,align,      " "},
           //{"DeEmphasis Removal",state2.ToString(),      " "},
           //{"Deemphasis Edges"  ,edge1,      " "},
           //{"method2"           ,method2,      " "},
           //{"lower_pct"         ,lower_pct.ToString(),      " "},
           //{"lower_volts"       ,lower_volts.ToString(),      " "},
           //{"level"             ,level.ToString(),      " "},
           //{"method3"           ,method3,      " "},
           //{"base_volts"        ,base_volts.ToString(),      " "}

           // };
            arraylist.array2Db[0, 1] = mode;
            arraylist.array2Db[1, 1] = edge;
            arraylist.array2Db[2, 1] = bandwidth;
            arraylist.array2Db[3, 1] = units;
            arraylist.array2Db[4, 1] = method;
            arraylist.array2Db[5, 1] = report;
            arraylist.array2Db[6, 1] = source;
            arraylist.array2Db[7, 1] = ber;
            arraylist.array2Db[8, 1] = plength;
            arraylist.array2Db[9, 1] = state.ToString();
            arraylist.array2Db[10, 1] = bandwidth1;
            arraylist.array2Db[11, 1] = location.ToString();
            arraylist.array2Db[12, 1] = units1;
            arraylist.array2Db[13, 1] = method1;
            arraylist.array2Db[14, 1] = report1;
            arraylist.array2Db[16, 1] = state1.ToString();
            arraylist.array2Db[17, 1] = type;
            arraylist.array2Db[18, 1] = start_frequency.ToString();
            arraylist.array2Db[19, 1] = stop_frequency.ToString();
            arraylist.array2Db[20, 1] = shape;
            arraylist.array2Db[21, 1] = rjSetting;
            arraylist.array2Db[22, 1] = rnSetting;
            arraylist.array2Db[23, 1] = clockMethod;
            arraylist.array2Db[24, 1] = clockMethod1;
            arraylist.array2Db[25, 1] = align;
            arraylist.array2Db[25, 1] = clock.ToString();
            arraylist.array2Db[26, 1] = state2.ToString();
            arraylist.array2Db[27, 1] = edge1;
            arraylist.array2Db[28, 1] = method2;
            arraylist.array2Db[29, 1] = lower_pct.ToString();
            arraylist.array2Db[30, 1] = lower_volts.ToString();
            arraylist.array2Db[31, 1] = level.ToString();
            arraylist.array2Db[32, 1] = method3;
            arraylist.array2Db[33, 1] = base_volts.ToString();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

 //           dataGridView1.ColumnCount = 4;
 //           dataGridView1.Columns[0].Name = "Variable name";
 //           dataGridView1.Columns[1].Name = "Value";
 //           dataGridView1.Columns[2].Name = "Frozen Value";
 //           dataGridView1.Columns[3].Name = "Difference?";

            for (int i = 0; i < elementCount; i++)
            {
                string[] row = new string[] { arraylist.array2Db[i, 0], arraylist.array2Db[i, 1], arraylist.array2Db[i, 2] };
                dataGridView1.Rows.Add(row);
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(500);//added for a breakpoint  
            //  dataGridView1.
            //Freezecopy Code
            for (int i = 0; i < 34; i++)
            {
               // string[] row = new string[] { arraylist.array2Db[i, 0], arraylist.array2Db[i, 1], arraylist.array2Db[i, 2] };
                arraylist.array2Db[i, 2] = arraylist.array2Db[i, 1];
                

            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            for (int i = 0; i < 34; i++)
            {
                string[] row = new string[] { arraylist.array2Db[i, 0], arraylist.array2Db[i, 1], arraylist.array2Db[i, 2] };
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.Refresh();

        }


    }

    public class arraylist                   // my arrays 
    {


        //string[,] array2Db = new string[elementCount, 3]
        public static string[,] array2Db = new string[34, 3];
        
    
    }



}
