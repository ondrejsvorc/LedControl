const int led = 9;
char state;

void setup() 
{
    pinMode(led, OUTPUT);
    Serial.begin(9600);
}

void loop() 
{
  while (Serial.available() > 0)
    {
        state = Serial.read();
   
        if (state == '1')
        {
            digitalWrite(led, HIGH);
        }
        else
        {   
            digitalWrite(led, LOW);
        }
    }
}
