import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ProductServiceProxy,
  ProductDto,
  ProductTypeDtoPagedResultDto,
  ProductTypeDto,
  ProductTypeServiceProxy
} from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: 'edit-product-dialog.component.html'
})
export class EditProductDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product: ProductDto = new ProductDto();
  id: number;
  productTypes: ProductTypeDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public _productTypeService: ProductTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._productService.get(this.id).subscribe((result: ProductDto) => {
      this.product = result;
    });
    this.getProductTypeList()
  }

  getProductTypeList(): void {
    this._productTypeService
      .getAll( "", 0, 100)
      .pipe( finalize(() => {}))
      .subscribe((result: ProductTypeDtoPagedResultDto) => { this.productTypes = result.items;});
  }

  save(): void {
    this.saving = true;

    this._productService.update(this.product).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
