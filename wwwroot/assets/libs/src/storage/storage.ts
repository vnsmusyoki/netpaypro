/**
 * Base Storage class. All storage implementation must inherit this class
 */
import { TData } from '../types';

abstract class Storage<I> {
  /**
   * Returns all rows based on ...args
   * @param args
   */
  abstract get(...args): Promise<StorageResponse>;

  /**
   * To set all rows
   *
   * @param data
   */
  set?(data: I | ((...args) => void)): this;
}

export interface StorageResponse {
  data: TData;
  total: number;
}

export default Storage;
