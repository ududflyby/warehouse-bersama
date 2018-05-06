Imports MySql.Data.MySqlClient
Public Class Form2

    Private Sub Barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilDatabarang()
    End Sub

    Sub bersihkan()
        txtBarang.Text = ""
        txtJumlah.Text = ""
        txtKeterangan.Text = ""
    End Sub

    Sub tampilDatabarang()
        Try
            Call koneksi()
            da = New MySqlDataAdapter("select * from databarang order by id_barang Asc", conn)
            ds = New DataSet
            da.Fill(ds, "databarang")
            dgvDatabarang.DataSource = ds.Tables("databarang")
        Catch ex As Exception

        End Try
    End Sub

    Sub simpanBarang()
        Try
            Call koneksi()
            Dim str As String
            str = "insert into databarang ( id_barang, jml_barang, keterangan) values ('" & txtBarang.Text & "','" & txtJumlah.Text & "','" & txtKeterangan.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Barang Berhasil Ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Insert Data Barang Gagal Dilakukan" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub

    Sub ubahBarang()
        Try
            Call koneksi()
            Dim str As String
            str = "update databarang set jml_barang = '" & txtJumlah.Text & "', keterangan = '" & txtKeterangan.Text & "' where id_barang =  '" & txtBarang.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Barang Berhasil Diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ubah Data Barang Gagal Dilakukan" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub

    Sub hapus()
        Try
            Call koneksi()
            Dim str As String
            str = "delete from databarang where id_barang='" & txtBarang.Text & "'"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Data Barang Berhasil Dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Data Barang Gagal Dihapus" + ex.Message, "Informasi", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInput.Click
        If MessageBox.Show("Yakin ingin menyimpan data jabatan", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call simpanBarang()
            Call bersihkan()
            Call tampilDatabarang()
        End If
    End Sub

    Private Sub btnUbah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If MessageBox.Show("Yakin ingin mengubah data barang", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call ubahBarang()
            Call bersihkan()
            Call tampilDatabarang()
        End If
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Yakin Ingin Menghapus Data Jabatan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call hapus()
            Call bersihkan()
            Call tampilDatabarang()
        End If
    End Sub

    Private Sub dgvDatabarang_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatabarang.CellMouseClick
        Try
            txtBarang.Text = dgvDatabarang.Rows(e.RowIndex).Cells(0).Value
            txtJumlah.Text = dgvDatabarang.Rows(e.RowIndex).Cells(1).Value
            txtKeterangan.Text = dgvDatabarang.Rows(e.RowIndex).Cells(2).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Visible = True
        Form3.Enabled = True
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Visible = True
        Form4.Enabled = True
        Me.Hide()
    End Sub
End Class