import { from } from 'rxjs';
import { delicacy } from '../Types/delicacy';

export const fakeDelicacy: delicacy[] = [
  {
    id: 2,
    name: 'bread',
    quantity: 5,
    price: 34,
    weight: 899,
    nutri_engy: 34,
    veg: false,
    spl: false,
  },
  {
    id: 3,
    name: 'pizza',
    quantity: 2,
    price: 359,
    weight: 899,
    nutri_engy: 89,
    veg: false,
    spl: true,
  },
  {
    id: 4,
    name: 'Puffs',
    quantity: 34,
    price: 20.9,
    weight: 90,
    nutri_engy: 12,
    veg: true,
    spl: false,
  },
];
