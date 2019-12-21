using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public class CRC16
    {
 
        static private readonly ushort [] crc_table = new ushort[256] {
            0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
            0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
            0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
            0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
            0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
            0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
            0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
            0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
            0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823,
            0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
            0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12,
            0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
            0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41,
            0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
            0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
            0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
            0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F,
            0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
            0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E,
            0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
            0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
            0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
            0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C,
            0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
            0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
            0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3,
            0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
            0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
            0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9,
            0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
            0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8,
            0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
        };

        static private ushort Crc_1byte(byte inV, ushort crc)
        {
            /*
             1byteづつCRCを計算する

             unsigned short crc;
             crc = 0xffff; // 初期値
             crc = crc_1byte(0xA1, crc);
             crc = crc_1byte(0xA1, crc);
             crc = crc_1byte(0xA1, crc);
             crc = crc_1byte(0xFE, crc); // A1 A1 A1 FE : ID ADDRESS MARK
             crc = crc_1byte(0x02, crc); // C
             crc = crc_1byte(0x00, crc); // H
             crc = crc_1byte(0x03, crc); // R
             crc = crc_1byte(0x02, crc); // N

             これで crc に計算結果が入る (0x4165)
            */

            return (ushort)(crc_table[((crc >> 8) ^ inV) & 0xFF] ^ (crc << 8));
        }
        static  public ushort Calc(byte [] buff, ushort size, ushort crc)
        {
            /*
             ブロックのCRCを計算する

             unsigned short crc;
             unsigned char buff[]=
             {
               0xA1,0xA1,0xA1,0xFE // ID ADDRESS MARK
              ,0x02 // C
              ,0x00 // H
              ,0x03 // R
              ,0x02 // N
              ,0x41 // CRC H
              ,0x65 // CRC L
             };
             crc = crc_block(buff, 8, 0xFFFF);
             これで crc に IDAM から N までの計算結果が入る (0x4165)

             crc = crc_block(buff,10, 0xFFFF);
             CRCを含めて計算すると、CRCが正しければ計算結果がゼロになる
            */
            ushort pos;

            for (pos = 0; pos != size; pos++)
            {
                crc = Crc_1byte(buff[pos], crc);
            }

            return crc;
        }
        static public ushort Calc(byte[] buff, int start, int sz, ushort crc)
        {
            /*
             ブロックのCRCを計算する

             unsigned short crc;
             unsigned char buff[]=
             {
               0xA1,0xA1,0xA1,0xFE // ID ADDRESS MARK
              ,0x02 // C
              ,0x00 // H
              ,0x03 // R
              ,0x02 // N
              ,0x41 // CRC H
              ,0x65 // CRC L
             };
             crc = crc_block(buff, 8, 0xFFFF);
             これで crc に IDAM から N までの計算結果が入る (0x4165)

             crc = crc_block(buff,10, 0xFFFF);
             CRCを含めて計算すると、CRCが正しければ計算結果がゼロになる
            */

            for (int i = 0; i < sz; i++)
            {
                crc = Crc_1byte(buff[start + i], crc);
            }

            return crc;
        }
       
        static ushort crc_1byteA(byte inB, ushort crc)
        {
            /* 1byteづつCRCを計算する
             wikipediaにある実装例を、テーブルを使わないように書き換えただけ。

             unsigned short crc;
             crc = 0xffff; // 初期値
             crc = crc_1byte(0xA1, crc);
             crc = crc_1byte(0xA1, crc);
             crc = crc_1byte(0xA1, crc);
             crc = crc_1byte(0xFE, crc); // A1 A1 A1 FE : ID ADDRESS MARK
             crc = crc_1byte(0x02, crc); // C
             crc = crc_1byte(0x00, crc); // H
             crc = crc_1byte(0x03, crc); // R
             crc = crc_1byte(0x02, crc); // N

             これで crc に計算結果が入る (0x4165)
             0x1021 / 0x8408
             0x8005 / 0xA001
            */
            const ushort polynomial = 0xA001; // 0x1021 多項式 CRC-16-CCITT X^16+X^12+X^5+X^0 (1 0001 0000 0010 0001)
                                              // 0x8005 //        CRC-16-IBM X^16+X^15+X^2+X^0 (1 1000 0000 0000 0101)
            byte bit;
            ushort a;

            a = (ushort)(((inB << 8) ^ crc) &0xFF00);
            for (bit = 8; bit != 0; bit--)
            {
                if (0 == (a & 0x8000)) a = (ushort)(a << 1); // 最上位ビットが0ならシフトのみ
                else a = (ushort)(polynomial ^ (a << 1));   // 最上位ビットが1ならシフトして多項式でXOR
            }
            crc = (ushort)(a ^ (crc << 8));

            return crc;
        }
        public static ushort CalcIBM(byte [] buff, int start, long size, ushort crc)
        {
            /*
             ブロックのCRCを計算する

             unsigned short crc;
             unsigned char buff[]=
             {
               0xA1,0xA1,0xA1,0xFE // ID ADDRESS MARK
              ,0x02 // C
              ,0x00 // H
              ,0x03 // R
              ,0x02 // N
              ,0x41 // CRC H
              ,0x65 // CRC L
             };
             crc = crc_block(buff, 8, 0xFFFF);
             これで crc に IDAM から N までの計算結果が入る (0x4165)

             crc = crc_block(buff,10, 0xFFFF);
             CRCを含めて計算すると、CRCが正しければ計算結果がゼロになる
            */

            for (int pos = 0; pos < size; pos++)
            {
                crc = crc_1byteA(buff[pos + start], crc);
            }

            return crc;
        }
        public static ushort Fletcher16(byte [] data, int start , int count)
        {
            ushort sum1 = 0;
            ushort sum2 = 0;

            for (int index = 0; index < count; ++index)
            {
                sum1 = (ushort)((sum1 + data[start+index]) % 255);
                sum2 = (ushort)((sum2 + sum1) % 255);
            }

            return (ushort)(((sum2 << 8) | sum1));
        }
    }
}
