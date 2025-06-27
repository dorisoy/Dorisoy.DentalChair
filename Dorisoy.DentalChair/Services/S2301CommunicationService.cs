using Dorisoy.DentalChair.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair.Services
{
    /// <summary>
    /// 牙科综合治疗机数据通信服务
    /// </summary>
    public class DentalChairCommunicationService
    {
        public DentalChairSerialPort DentalChairSerialPort { get; }

        public DentalChairCommunicationService(DentalChairSerialPort serialDataInteraction)
        {
            DentalChairSerialPort = serialDataInteraction;
        }

        /// <summary>
        /// 牙椅-升
        /// </summary>
        public void ChairControlUp()
        {
            DentalChairSerialPort.SendData(0x0C, [0x01]);
        }

        /// <summary>
        /// 牙椅-降
        /// </summary>
        public void ChairControlDown()
        {
            DentalChairSerialPort.SendData(0x0C, [0x02]);
        }

        /// <summary>
        /// 牙椅-俯
        /// </summary>
        public void ChairControlProne()
        {
            DentalChairSerialPort.SendData(0x0C, [0x03]);
        }

        /// <summary>
        /// 牙椅-仰
        /// </summary>
        public void ChairControlUpward()
        {
            DentalChairSerialPort.SendData(0x0C, [0x04]);
        }

        /// <summary>
        /// 牙椅-停
        /// </summary>
        public void ChairControlStop()
        {
            DentalChairSerialPort.SendData(0x0C, [0x00, 0x01]);
        }

        /// <summary>
        /// 椅位0
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControl0(int height, int angle)
        {
            DentalChairHeightAngleSettings(0x05, height, angle);
        }

        /// <summary>
        /// 椅位1
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControl1(int height, int angle)
        {
            DentalChairHeightAngleSettings(0x06, height, angle);
        }
        /// <summary>
        /// 椅位2
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControl2(int height, int angle)
        {
            DentalChairHeightAngleSettings(0x07, height, angle);
        }

        /// <summary>
        /// 椅位3
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControl3(int height, int angle)
        {
            DentalChairHeightAngleSettings(0x08, height, angle);
        }

        /// <summary>
        /// 吐痰位
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControlLP(int height, int angle)
        {
            DentalChairHeightAngleSettings(0x09, height, angle);
        }

        /// <summary>
        /// 急救位
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControlFirstAid(int height, int angle)
        {
            DentalChairHeightAngleSettings(0x0A, height, angle);
        }

        /// <summary>
        /// 下班位
        /// </summary>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        public void ChairControlAfterWork(int height, int angle)
        {

        }

        /// <summary>
        /// 牙椅-椅位：0、1、2、3、急救、吐痰(LP)、下班
        /// </summary>
        private void DentalChairHeightAngleSettings(byte chair_code, int height, int angle)
        {
            var _height = DentalChairSerialPort.NumberToHighLowByte(height);
            var _angle = DentalChairSerialPort.NumberToHighLowByte(angle);
            DentalChairSerialPort.SendData(0x0C, [chair_code, 0x00, _height.highByte, _height.lowByte, _angle.highByte, _angle.lowByte]);
        }

        /// <summary>
        /// 滑轨-前进
        /// </summary>
        public void SlideRailForward()
        {
            DentalChairSerialPort.SendData(0x0E, [0x01]);
        }

        /// <summary>
        /// 滑轨-后退
        /// </summary>
        public void SlideRailRecoil()
        {
            DentalChairSerialPort.SendData(0x0E, [0x02]);
        }

        /// <summary>
        /// 滑轨-停止
        /// </summary>
        public void SlideRailStop()
        {
            DentalChairSerialPort.SendData(0x0E, [0x00, 0x01]);
        }

        /// <summary>
        /// 器械盘-升
        /// </summary>
        public void InstrumentTrayUp()
        {
            DentalChairSerialPort.SendData(0x0E, [0x03]);
        }

        /// <summary>
        /// 器械盘-降
        /// </summary>
        public void InstrumentTrayDown()
        {
            DentalChairSerialPort.SendData(0x0E, [0x04]);
        }

        /// <summary>
        /// 器械盘-停
        /// </summary>
        public void InstrumentTrayStop()
        {
            DentalChairSerialPort.SendData(0x0E, [0x00, 0x01]);
        }

        /// <summary>
        /// 开灯
        /// </summary>
        public void LightTurnOn()
        {
            DentalChairSerialPort.SendData(0x06, [0x02]);
        }

        /// <summary>
        /// 关灯
        /// </summary>

        public void LightTurnOff()
        {
            DentalChairSerialPort.SendData(0x06, [0x01]);
        }

        /// <summary>
        /// 加热水杯-开
        /// </summary>
        public void HotWaterOn()
        {
            DentalChairSerialPort.SendData(0x05, [0x02]);
        }

        /// <summary>
        /// 加热水杯-关
        /// </summary>
        public void HotWaterOff()
        {
            DentalChairSerialPort.SendData(0x05, [0x03]);
        }

        /// <summary>
        /// 漱口水
        /// </summary>
        public void MouthWash()
        {
            DentalChairSerialPort.SendData(0x07, [0x03]);
        }

        /// <summary>
        /// 冲盂
        /// </summary>
        public void FlushingCup()
        {
            DentalChairSerialPort.SendData(0x08, [0x04, 0x3c]);
        }

        /// <summary>
        /// 痰盂左转
        /// </summary>

        public void CuspidorLeft()
        {
            DentalChairSerialPort.SendData(0x08, [0x02, 0x00, 0x01]);
        }

        /// <summary>
        /// 痰盂右转
        /// </summary>

        public void CuspidorRight()
        {
            DentalChairSerialPort.SendData(0x08, [0x02, 0x00, 0x02]);
        }

        /// <summary>
        /// 痰盂停止
        /// </summary>
        public void CuspidorStop()
        {
            DentalChairSerialPort.SendData(0x08, [0x03]);
        }

        /// <summary>
        /// 清洗
        /// </summary>
        public void Cleanout()
        {
            DentalChairSerialPort.SendData(0x15, [0x03]);
        }

        /// <summary>
        /// 消毒
        /// </summary>
        public void Disinfection()
        {
            DentalChairSerialPort.SendData(0x14, [0x04]);
        }
    }
}
