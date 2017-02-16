import { Product } from '../product.model';
import { Language } from '../language.model';
import { ProductLanguage } from './product.language.model';
import { User } from '../user.model';

export class UserProduct {
    parentId: number;
    productId: number;
    // addedDate: string;
    // buyingDate: string;
    parent: User;
    product: Product;
}