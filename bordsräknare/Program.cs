using System;
using System.Collections.Generic;
using System.Globalization;

//
// RPN bordsräknare i Csharp
//
// stora tal ?? dvs BCD ? med fixed ?
//
// exempel:
//   2+3x4 :                  P3 *4 +2
//   (2+3)/4:                 P2 +3 /4
//   kvadratrot( 2^2 + 3^2):  kvadrat2 2 kvadrat2 3 + kvadratrot
//   kvadratrot( 2^2 + 3^4):  kvadrat2 2 P 3 kvadratX 4 + kvadratrot
//
// X = alias för pos 0 i stacken   X alltid synlig
// Y =  -*-          1
// Z = -*-           2
// T = -*-           3
//
namespace bordsräknare
{

}
