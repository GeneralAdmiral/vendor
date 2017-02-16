import { UserProduct } from './many_to_many/user.product.model';
import { ProductLanguage } from './many_to_many/product.language.model';
import { User } from './user.model';

export class Product {
    id: number ;
    image: ArrayBuffer;
    update: Date = new Date();
    userUpdateId: number;
    productLanguages: ProductLanguage[] = [];
    userProducts: UserProduct[] = [];
    userUpdate: User = new User();
}