// using System;
// using Goods;
// using Goods.Goods;
//
// namespace Transport.Semitrailers
// {
//     public class Refrigerator:Semitrailer
//     {
//         public Refrigerator()
//         {
//             MaxLoadWeight = 1350;
//             CurrentLoadWeight = 200;
//             Cargo = null;
//         }
//
//         public override void LoadTrailer(int weight, Cargo goods)
//         {
//             if (goods)
//             {
//                 if (Cargo is not null)
//                     base.LoadTrailer();
//             }
//             else
//             {
//                 
//             }
//         }
//     }
// }