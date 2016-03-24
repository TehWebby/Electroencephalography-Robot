#include <ZumoMotors.h>
#define LED_PIN 13

ZumoMotors motors;
int x;
int str;
int speed = 0;
int limit = 400;
  
void setup(){  
  Serial.begin(9600);
  pinMode(LED_PIN, OUTPUT);
  Serial.setTimeout(100);
  digitalWrite(LED_PIN, LOW); 
}

void loop(){
  if (Serial.available()){ 
    str = Serial.parseInt(); 

    //used a custom timer when coding to increase performance
    //unsigned long start = micros();
    
    //ensure the direction entered is valid
    if (isValid(str)){
      //set the speed to negative if command is reverse (2)
      if (str == 2)
        setReverseSpeed();
      setMotors(str);
    }
    resetValues();

    //used a custom timer when coding to increase performance
    //unsigned long end = micros();
    //unsigned long delta = end - start;
    //Serial.println(delta);
  }
}

void setMotors(int dir){
  //use pointer to ref speed
  //as we can keep the existing speed if we don't change it
  //can minimize code by this method
  int *lSpeed = &speed;
  int *rSpeed = &speed;
  if (dir == 3){
    lSpeed = 0;
  }else if (dir == 4){
    rSpeed = 0;
  }

  //loop from 0 to 400
  //unless reverse is active then speed=-400,limit=0
  //allows 1 loop to do the same for all directions
  for (speed; speed <= limit; speed++)
  {
    motors.setRightSpeed(*rSpeed);
    motors.setLeftSpeed(*lSpeed);
    delay(2);
  }
  //after the movement has completed, stop the motors (set speed to 0)
  stopMotors();
  Serial.println(speed);
  Serial.println(limit);
  
}

bool isValid(int dir){
  Serial.println("num");
  Serial.println(dir);
  //ensure the direction entered is valid
  if (dir > 0 && dir < 5){     
    return true;
  }
  else
    return false;
}

void setReverseSpeed(){
  speed = limit*-1;
  limit = 0;
}

void resetValues(){
  speed = 0;
  limit = 400;
}

void stopMotors(){
  motors.setRightSpeed(0);
  motors.setLeftSpeed(0);
}

