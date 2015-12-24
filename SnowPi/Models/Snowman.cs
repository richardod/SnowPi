using System.Collections.Generic;
using Prism.Mvvm;

namespace SnowPi.Models
{
    public class Snowman : BindableBase
    {
        private readonly Dictionary<Led, bool> _ledStatuses;

        public Snowman()
        {
            _ledStatuses = new Dictionary<Led, bool>(9);
        }

        // Can't get indexer binding working in universal apps, but is still useful with fluent API
        public bool this[Led led]
        {
            get
            {
                bool isSet;
                _ledStatuses.TryGetValue(led, out isSet);
                return isSet;
            }

            set { _ledStatuses[led] = value; }
        }

        public bool LedOneSet
        {
            get { return this[Led.One]; }
            set
            {
                if (this[Led.One] != value)
                {
                    this[Led.One] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedTwoSet
        {
            get { return this[Led.Two]; }
            set
            {
                if (this[Led.Two] != value)
                {
                    this[Led.Two] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedThreeSet
        {
            get { return this[Led.Three]; }
            set
            {
                if (this[Led.Three] != value)
                {
                    this[Led.Three] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedFourSet
        {
            get { return this[Led.Four]; }
            set
            {
                if (this[Led.Four] != value)
                {
                    this[Led.Four] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedFiveSet
        {
            get { return this[Led.Five]; }
            set
            {
                if (this[Led.Five] != value)
                {
                    this[Led.Five] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedSixSet
        {
            get { return this[Led.Six]; }
            set
            {
                if (this[Led.Six] != value)
                {
                    this[Led.Six] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedSevenSet
        {
            get { return this[Led.Seven]; }
            set
            {
                if (this[Led.Seven] != value)
                {
                    this[Led.Seven] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedEightSet
        {
            get { return this[Led.Eight]; }
            set
            {
                if (this[Led.Eight] != value)
                {
                    this[Led.Eight] = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool LedNineSet
        {
            get { return this[Led.Nine]; }
            set
            {
                if (this[Led.Nine] != value)
                {
                    this[Led.Nine] = value;
                    OnPropertyChanged();
                }
            }
        }

        public SnowPiLightShowRecording Setup()
        {
            return new SnowPiLightShowRecording(this);
        }

        /// <summary>
        ///     Resets- turns all LEDs off
        /// </summary>
        public void Reset()
        {
            LedOneSet = false;
            LedTwoSet = false;
            LedThreeSet = false;
            LedFourSet = false;
            LedFiveSet = false;
            LedSixSet = false;
            LedSevenSet = false;
            LedEightSet = false;
            LedNineSet = false;
        }
    }
}