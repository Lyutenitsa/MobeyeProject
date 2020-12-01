using Mobeye_API.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.DtosTest
{
    public class AlarmUpdateDtoTest
    {
        private AlarmUpdateDto _alarm;

        public AlarmUpdateDtoTest()
        {
            _alarm = new AlarmUpdateDto()
            {
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
        }
        [Fact]
        public void GetConfirmed_DeniedTest()
        {
            Assert.Equal("Confirmed", _alarm.Confirmed_Denied);
        }
        [Fact]
        public void SetConfirmed_DeniedTest()
        {
            _alarm.Confirmed_Denied = "Denied";
            Assert.Equal("Denied", _alarm.Confirmed_Denied);
        }
        [Fact]
        public void GetConfirmed_AtTest()
        {
            Assert.Equal(DateTime.Today, _alarm.Confirmed_at);
        }
        [Fact]
        public void SetConfirmed_AtTest()
        {
            _alarm.Confirmed_at = DateTime.Today.AddDays(2);
            Assert.Equal(DateTime.Today.AddDays(2), _alarm.Confirmed_at);
        }
        [Fact]
        public void ConfirmedDeniedTypeTest()
        {
            Assert.IsType<string>(_alarm.Confirmed_Denied);
        }
        [Fact]
        public void Confirmed_AtTypeTest()
        {
            Assert.IsType<DateTime>(_alarm.Confirmed_at);
        }
    }
}
