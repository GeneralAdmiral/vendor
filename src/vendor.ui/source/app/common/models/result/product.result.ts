import { Product } from '../product.model';
import { ValidationResult } from './validation.result';

export class ResultProduct {
    error: ValidationResult = new ValidationResult();
    results: Product[] = [];
    /// Не работает - undefined
    // public get product(): Product {
    //     return this.results[0];
    // }
}