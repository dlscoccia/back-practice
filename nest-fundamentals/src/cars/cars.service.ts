import { BadRequestException, Injectable } from '@nestjs/common';
import { v4 as uuid } from 'uuid';
import { Car } from './interfaces/car.interface';
import { CreateCarDto, UpdateCarDto } from './dto';

@Injectable()
export class CarsService {
  private cars: Car[] = [
    { id: uuid(), brand: 'Toyota', model: 'Corolla' },
    { id: uuid(), brand: 'Mazda', model: '3' },
    { id: uuid(), brand: 'Jeep', model: 'Cherokee' },
  ];

  findAll() {
    return this.cars;
  }

  findOneById(id: string) {
    return this.cars.find((car) => car.id === id);
  }

  create(createCarDto: CreateCarDto) {
    const newCar: Car = {
      id: uuid(),
      ...createCarDto,
    };

    this.cars.push(newCar);

    return newCar;
  }

  update(id: string, updateCarDto: UpdateCarDto) {
    let carDb = this.findOneById(id);

    if (updateCarDto.id && updateCarDto.id !== id)
      throw new BadRequestException(`Invalid car id`);

    this.cars = this.cars.map((car) => {
      if (car.id === id) {
        carDb = { ...car, ...updateCarDto, id };
        return carDb;
      }

      return car;
    });
  }

  delete(id: string) {
    this.findOneById(id);
    this.cars = this.cars.filter((car) => car.id !== id);
  }
}
