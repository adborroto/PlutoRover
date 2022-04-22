# Pluto Rover Coding Exercise

## Description

After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Rover
to further investigate the surface. You are responsible for developing an API that will allow
the Rover to move around the planet. As you won’t get a chance to fix your code once it is
onboard, you are expected to use test driven development.
To simplify navigation, the planet has been divided up into a grid. The rover's position and
location is represented by a combination of x and y coordinates and a letter representing
one of the four cardinal compass points. An example position might be 0, 0, N, which
means the rover is in the bottom left corner and facing North. Assume that the square
directly North from (x, y) is (x, y+1).
In order to control a rover, NASA sends a simple string of letters. The only commands you
can give the rover are ‘F’,’B’,’L’ and ‘R’.

## Coding Exercise

The repo is divided in two main sections `/src` for the source code and `/tests` for testing projects.

Inside the `/src` you will be able to find the **Domain** project that contains all domain logic for the Rover. With **Rover** as a aggregator root and value objects as **Position**, **Direction**. 


## Rover commands

The solution contains basic commands for the rover like **Move forward**, **Move backward**, **Turn Left** and **Turn Right** etc.
Rover commands can be extended using the `IRoverCommand` interface.

```
public interface IRoverCommand
{
    void Execute(Rover rover);
    
    char CommandName { get; }
}

public class MoveInCircle : IRoverCommand{
    char CommandName => 'C';

    public void Execute(Rover rover){
        ...
    }
}

```

## Rover control
There is also a **Services** project with the **RoverControl** class which is the responsible to execute the commands for the rover. The RoverControl expect a command provider `IRoverCommandProvider`.

```
var control = new RoverControl(...);
control.Execute("FFFFBBB");

```

# Architectural Design

![Architectural Design](assets/flow.png?raw=true "Architectural Design")

1. We expect that Rover notifies when it is ready to send information.
2. We have to be ready for the Rover that is why we have a scalable **Live Data Collector** with a **Load balancer** that will be in charge of collect all the information received.
3. Live Data Collector can't miss any request, that is why it will use a **Queue** to only dispatch the information received. 
4. Then  a list of **Workers** will appear on demand based on the queue publish rate or message count. The worker have two main responsibilities. First process and store the received information in a TSDB. Second, notify the LiveUpdate-app.
5. Since the data received will be query based on a date range, we can use data sharding for the **Time Series Database** (TSDB).
6. The **Dashboard-app** will receive push notifications from the **LiveUpdate-App** (for real time updates) and also will consume the TSDB using a **Data Aggregator** (for historical data).
7. The user browsers will connect with the **Dashboard-app** using WebSocket for real time update and REST for historical data.