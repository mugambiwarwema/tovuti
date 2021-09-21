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
  ProductTypeServiceProxy,
  ProductTypeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-product-type-dialog.component.html'
})
export class EditProductTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  productType: ProductTypeDto = new ProductTypeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productTypeService: ProductTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._productTypeService.get(this.id).subscribe((result: ProductTypeDto) => {
      this.productType = result;
    });
  }

  save(): void {
    this.saving = true;

    this._productTypeService.update(this.productType).subscribe(
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
