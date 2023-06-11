#include <ADC.h>
#include <cmath>
#include<SPI.h>
#include <libpq-fe.h>

#define CS_PIN 14

IntervalTimer ADCTimer;

// instantiate a new ADC object
ADC *adc = new ADC(); // adc object;

const int pin = 14;
const int n = 1000;


const int admarkpin  = 1;

int sample_rate = 1000000;
int sample_read = -1;
int sample_rate_choose;

// ADMARKHI and ADMARKLO are used to observe timing on oscilloscope
#define  ADMARKHI digitalWriteFast(admarkpin, HIGH);
#define  ADMARKLO digitalWriteFast(admarkpin, LOW);

#define ADMAX 300000
uint8_t adcbuffer[ADMAX];
volatile uint32_t adcidx;
volatile bool doneflag = false;

void setup() {
  /
  while (!Serial) {}
  Serial.begin(67200);
  
  pinMode(admarkpin, OUTPUT);
  pinMode(pin, INPUT);
  adc->adc0->setAveraging(1); // set number of averages
  adc->adc0->setResolution(10); // set bits of resolution
  adc->adc0->setConversionSpeed(ADC_CONVERSION_SPEED::HIGH_SPEED); // change the conversion speed
  adc->adc0->setSamplingSpeed(ADC_SAMPLING_SPEED::HIGH_SPEED); // change the sampling speed
  
}



void loop() {

  while(sample_read == -1)
  {
    sample_read = Serial.read();
    if(sample_read > 48 and sample_read < 55)
    {
      sample_rate_choose = sample_read - 48;
      if(sample_rate_choose == 1)   //sample_rate = 10KHz
      {
        sample_rate = 100 - 2;
      }
      else if(sample_rate_choose == 2)   //sample_rate = 20KHz   
      {
        sample_rate = 50 - 2;
      }
      else if(sample_rate_choose == 3)   //sample_rate = 50KHz   
      {
        sample_rate = 20 - 2;
      }
      else if(sample_rate_choose == 4)   //sample_rate = 100KHz   
      {
        sample_rate = 10 - 2;
      }
      else if(sample_rate_choose == 5)   //sample_rate = 200KHz   
      {
        sample_rate = 5 - 2;
      }
      else if(sample_rate_choose == 6)   //sample_rate = 250KHz   
      {
        sample_rate = 4-2;
      }
    }
    else
    {
      sample_read = -1;
    }
  }

  if(Serial.read()- 48 == 7)
  {
    sample_read = -1;
  }
  
  Serial.println(analogRead(pin));
  
  delayMicroseconds(sample_rate);
}
