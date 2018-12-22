using System.ComponentModel;

namespace Citi.Data
{
    public enum Symbol
    {
        [Description("American Airlines Group In")] AAL,
        [Description("Apple Inc")] AAPL,
        [Description("Adobe Inc.")] ADBE,
        [Description("Analog Devices Inc")] ADI,
        [Description("Automatic Data Processing Inc")] ADP,
        [Description("Autodesk Inc")] ADSK,
        [Description("Align Technology Inc")] ALGN,
        [Description("Alexion Pharmaceuticals Inc")] ALXN,
        [Description("Applied Materials Inc")] AMAT,
        [Description("Amgen Inc")] AMGN

//        AMZN    Amazon.com Inc	1377.45	 	-83.3801	-5.71%
//ATVI    Activision Blizzard Inc	45.85	 	-1.20	-2.55%
//ASML    ASML Holding NV	148.45	 	-4.23	-2.77%
//AVGO    Broadcom Inc	244.91	 	3.02	1.25%
//BIDU    Baidu Inc	157.42	 	-2.94	-1.83%
//BIIB    Biogen Inc	280.60	 	-11.73	-4.01%
//BMRN    Biomarin Pharmaceutical Inc	80.92	 	-4.91	-5.72%
//CDNS    Cadence Design Systems Inc	40.69	 	-0.87	-2.09%
//CELG    Celgene Corp	60.92	 	-3.60	-5.58%
//CERN    Cerner Corp	49.21	 	-1.47	-2.90%
//CHKP    Check Point Software Technologies Ltd	100.04	 	-3.09	-3.00%
//CHTR    Charter Communications Inc	283.93	 	-6.52	-2.24%
//CTRP    Ctrip.Com International Ltd	26.49	 	0.18	0.68%
//CTAS    Cintas Corp	159.97	 	0.93	0.58%
//CSCO    Cisco Systems Inc	41.85	 	-0.64	-1.51%
//CTXS    Citrix Systems Inc	100.76	 	-2.44	-2.36%
//CMCSA   Comcast Corp	33.75	 	-0.87	-2.51%
//COST    Costco Wholesale Corp	194.52	 	-2.61	-1.32%
//CSX CSX Corp	60.70	 	-0.91	-1.48%
//CTSH    Cognizant Technology Solutions Corp	60.09	 	-2.69	-4.28%
//DISH    DISH Network Corp	25.02	 	-1.46	-5.51%
//DLTR    Dollar Tree Inc	83.46	 	-0.31	-0.37%
//EA  Electronic Arts	76.57	 	-0.87	-1.12%
//EBAY    eBay Inc	26.58	 	-1.41	-5.04%
//ESRX	---	---	
//---
//---	---
//EXPE    Expedia Group Inc	110.15	 	-4.16	-3.64%
//FAST    Fastenal Co	50.43	 	-0.14	-0.28%
//FB  Facebook	124.95	 	-8.45	-6.33%
//FISV    Fiserv Inc	70.92	 	-1.58	-2.18%
//FOX Twenty-First Century Fox Inc	46.60	 	-1.13	-2.37%
//FOXA    Twenty-First Century Fox Inc	46.90	 	-1.10	-2.29%
//GILD    Gilead Sciences Inc	62.62	 	-1.68	-2.61%
//GOOG    Alphabet Class C	979.54	 	-29.87	-2.96%
//GOOGL   Alphabet Class A	991.25	 	-32.33	-3.16%
//HAS Hasbro Inc	78.11	 	-0.98	-1.24%
//HSIC    Henry Schein Inc	75.96	 	-1.20	-1.56%
//HOLX    Hologic Inc	38.41	 	-0.18	-0.47%
//ILMN    Illumina Inc	278.86	 	-13.39	-4.58%
//INCY    Incyte Corp	58.67	 	-3.06	-4.96%
//INTC    Intel Corp	44.84	 	-0.70	-1.54%
//INTU    Intuit Inc	185.81	 	-6.25	-3.25%
//ISRG    Intuitive Surgical Inc	446.02	 	-13.86	-3.01%
//Symbol
//Name
//Price


//Change
//%Change
//IDXX    IDEXX Laboratories Inc	184.94	 	-0.10	-0.05%
//JBHT    J.B. Hunt Transport Services Inc	90.85	 	-1.58	-1.71%
//JD  JD.com Inc	21.08	 	1.17	5.88%
//KLAC    KLA-Tencor Corp	85.67	 	-0.23	-0.27%
//KHC Kraft Heinz Co	44.05	 	-0.80	-1.78%
//LBTYA   Liberty Global PLC	20.83	 	-1.14	-5.19%
//LBTYK   Liberty Global PLC	20.06	 	-1.03	-4.88%
//LRCX    Lam Research Corp	127.16	 	-1.15	-0.90%
//MELI    MercadoLibre Inc	286.56	 	-19.84	-6.48%
//MAR Marriott International Inc	102.88	 	-1.31	-1.26%
//MCHP    Microchip Technology Inc	67.99	 	-0.72	-1.05%
//MDLZ    Mondelez International Inc	40.68	 	-0.48	-1.17%
//MNST    Monster Beverage Corp	48.23	 	-0.98	-1.99%
//MSFT    Microsoft Corp	98.23	 	-3.28	-3.23%
//MU  Micron Technology Inc	30.32	 	-0.96	-3.07%
//MXIM    Maxim Integrated Products Inc	48.22	 	-0.60	-1.23%
//MYL Mylan NV	26.46	 	-0.90	-3.29%
//NFLX    Netflix Inc	246.39	 	-14.19	-5.45%
//NTES    NetEase Inc	244.43	 	8.61	3.65%
//NVDA    NVIDIA Corp	129.57	 	-5.53	-4.09%
//NXPI    NXP Semiconductors NV	70.34	 	-1.61	-2.24%
//ORLY    O'Reilly Automotive Inc	330.57	 	-2.12	-0.64%
//PAYX    Paychex Inc	63.84	 	-1.12	-1.72%
//PCAR    PACCAR Inc	54.90	 	-0.51	-0.92%
//BKNG    Booking Holdings Inc	1633.39	 	-71.79	-4.21%
//PYPL    PayPal Holdings Inc	78.14	 	-4.30	-5.22%
//QCOM    Qualcomm Inc	54.85	 	-1.52	-2.70%
//QRTEA   Qurate Retail Inc	18.45	 	-0.15	-0.81%
//REGN    Regeneron Pharmaceuticals Inc	344.60	 	-11.63	-3.26%
//ROST    Ross Stores Inc	76.98	 	-0.18	-0.23%
//STX Seagate Technology PLC	36.36	 	-0.22	-0.60%
//SHPG    Shire PLC	170.03	 	-1.18	-0.69%
//SIRI    Sirius XM Holdings Inc	5.59	 	-0.30	-5.09%
//SWKS    Skyworks Solutions Inc	64.49	 	-1.15	-1.75%
//SBUX    Starbucks Corp	61.39	 	-0.76	-1.22%
//SYMC    Symantec Corp	18.44	 	-1.12	-5.73%
//SNPS    Synopsys Inc	80.80	 	-2.90	-3.46%
//TTWO    Take-Two Interactive Software Inc	101.37	 	-0.73	-0.71%
//TSLA    Tesla Inc	319.77	 	4.39	1.39%
//TXN Texas Instruments Inc	90.41	 	0.32	0.36%
//TMUS    T-Mobile US Inc	61.93	 	-2.33	-3.63%
//ULTA    Ulta Beauty Inc	230.49	 	-3.52	-1.50%
//VOD Vodafone Group PLC	19.35	 	-0.65	-3.25%
//VRTX    Vertex Pharmaceuticals Inc	156.50	 	-4.80	-2.98%
//WBA Walgreens Boots Alliance Inc	67.26	 	-2.35	-3.38%
//WDC Western Digital Corp	35.90	 	-0.79	-2.15%
//WDAY    Workday Inc	144.93	 	-7.13	-4.69%
//VRSK    Verisk Analytics Inc	106.01	 	-2.46	-2.27%
//WYNN    Wynn Resorts Ltd	93.41	 	-4.39	-4.49%
//XEL Xcel Energy Inc	50.90	 	-0.47	-0.91%
//XLNX
    }
}